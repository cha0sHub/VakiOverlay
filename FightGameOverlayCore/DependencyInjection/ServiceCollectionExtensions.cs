using FightGameOverlayCore.Controllers;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Models;
using FightGameOverlayCore.Interfaces.PluginSupport;
using FightGameOverlayCore.Models;
using FightGameOverlayCore.PluginSupport;
using Microsoft.Extensions.DependencyInjection;

namespace FightGameOverlayCore.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFightGameOverlayServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IChangeLayoutController, ChangeLayoutController>();
            serviceCollection.AddTransient<IDataManagerController, DataManagerController>();
            serviceCollection.AddTransient<ILayoutController, LayoutController>();
            serviceCollection.AddTransient<IOverlayController, OverlayController>();
            serviceCollection.AddSingleton<IMatchModel, MatchModel>();

            return serviceCollection;
        }
    }
}
