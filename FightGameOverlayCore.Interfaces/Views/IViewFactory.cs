
using FightGameOverlayCore.Interfaces.Controllers;

namespace FightGameOverlayCore.Interfaces.Views
{
    public interface IViewFactory
    {
        IDataManagerView GetDataManagerView(IDataManagerController controller);
        IOverlayView GetOverlayView(IOverlayController controller);
        IChangeLayoutView GetChangeLayoutView(IChangeLayoutController controller);
        ILayoutConfigurationView GetLayoutConfigurationView(ILayoutController controller);
    }
}
