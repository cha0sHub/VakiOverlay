using FightGameOverlayCore.Interfaces.PluginSupport;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace FightGameOverlayCore.PluginSupport
{
    public class PluginManager : IPluginManager
    {
        private string PluginPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins/");

        private List<Type> PluginTypes { get; }
        private List<IPlugin> Plugins { get; }

        public PluginManager()
        {
            PluginTypes = new List<Type>();
            Plugins = new List<IPlugin>();
        }

        public void DiscoverPlugins(IServiceCollection serviceCollection)
        {
            var pluginFiles = Directory.GetFiles(PluginPath, "*.dll");

            foreach (var pluginFile in pluginFiles)
            {
                var a = Assembly.LoadFile(pluginFile);

                var plugins =  from t in a.DefinedTypes
                       from i in t.ImplementedInterfaces
                       where i.AssemblyQualifiedName != null
                           && i.AssemblyQualifiedName.Equals(typeof(IPlugin).AssemblyQualifiedName)
                       let loadedA = Assembly.LoadFrom(pluginFile)
                       select loadedA.GetType(t.FullName);

                foreach (var plugin in plugins)
                {
                    serviceCollection.AddTransient(plugin);
                    PluginTypes.Add(plugin);
                }
            }
        }

        public void ShutdownPlugins()
        {
            foreach (var plugin in Plugins)
            {
                plugin.Shutdown();
            }
        }

        public void StartPlugins(IServiceProvider serviceProvider)
        {
            foreach (var pluginType in PluginTypes)
            {
                var plugin = (IPlugin)serviceProvider.GetService(pluginType);
                plugin.Start();
                Plugins.Add(plugin);
            }
        }
    }
}
