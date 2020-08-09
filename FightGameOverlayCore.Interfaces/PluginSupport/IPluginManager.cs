using Microsoft.Extensions.DependencyInjection;
using System;

namespace FightGameOverlayCore.Interfaces.PluginSupport
{
    public interface IPluginManager
    {
        void DiscoverPlugins(IServiceCollection serviceCollection);
        void StartPlugins(IServiceProvider serviceProvider);
        void ShutdownPlugins();
    }
}
