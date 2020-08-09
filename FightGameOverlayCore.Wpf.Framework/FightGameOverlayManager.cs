using FightGameOverlayCore.Configuration;
using FightGameOverlayCore.DependencyInjection;
using FightGameOverlayCore.Interfaces;
using FightGameOverlayCore.Interfaces.Configuration;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.PluginSupport;
using FightGameOverlayCore.PluginSupport;
using FightGameOverlayCore.Wpf.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace FightGameOverlayCore.Wpf
{
    internal class FightGameOverlayManager : IFightGameOverlayManager
    {
        private IServiceProvider ServiceProvider { get; set; }
        private IPluginManager PluginManager { get; set; }

        public void Configure()
        {
            PluginManager = new PluginManager();
            var serviceCollection = new ServiceCollection();
            PluginManager.DiscoverPlugins(serviceCollection);
            serviceCollection.AddFightGameOverlayServices();
            serviceCollection.AddWpfServices();
            serviceCollection.AddSingleton<IFightGameOverlayManager>(this);
            
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void DisplayChangeLayoutWindow()
        {
            var changeLayoutController = ServiceProvider.GetService<IChangeLayoutController>();
            changeLayoutController.Display();
        }

        public void DisplayAddNewLayoutWindow()
        {
            var layoutController = ServiceProvider.GetService<ILayoutController>();
            layoutController.Layout = new LayoutConfiguration();
            layoutController.Display();
        }

        public void DisplayEditLayoutWindow(ILayoutConfiguration layoutConfiguration)
        {
            var layoutController = ServiceProvider.GetService<ILayoutController>();
            layoutController.Layout = layoutConfiguration.Copy();
            layoutController.Display();
        }

        public void ShutdownApplication()
        {
            PluginManager.ShutdownPlugins();
            Application.Current.Shutdown();
        }

        public void Start()
        {
            PluginManager.StartPlugins(ServiceProvider);
            var userSettingsManager = ServiceProvider.GetService<IUserSettingsManager>();
            userSettingsManager.Initialize();
            var layoutManager = ServiceProvider.GetService<ILayoutManager>();
            layoutManager.DiscoverLayouts();
            var dataManagerController = ServiceProvider.GetService<IDataManagerController>();
            dataManagerController.Display();
            var overlayController = ServiceProvider.GetService<IOverlayController>();
            overlayController.Display();
        }
    }
}
