using FightGameOverlayCore.Configuration;
using FightGameOverlayCore.Interfaces.Configuration;
using FightGameOverlayCore.Interfaces.Views;
using FightGameOverlayCore.Wpf.Views;
using Microsoft.Extensions.DependencyInjection;

namespace FightGameOverlayCore.Wpf.DependencyInjection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWpfServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILayoutManager, LayoutManager>();
            serviceCollection.AddSingleton<IUserSettingsManager, UserSettingsManager>();
            serviceCollection.AddTransient<IViewFactory, WpfViewFactory>();

            return serviceCollection;
        }
    }
}
