using System;
using System.Collections.Generic;

namespace FightGameOverlayCore.Interfaces.Configuration
{
    public interface ILayoutManager
    {
        event EventHandler LayoutChanged;
        event EventHandler LayoutAddedOrModified;
        ILayoutConfiguration CurrentLayout { get; set; }
        IEnumerable<ILayoutConfiguration> AvailableLayouts { get; }
        void DiscoverLayouts();
        void SaveLayout(ILayoutConfiguration layoutConfiguration);
    }
}
