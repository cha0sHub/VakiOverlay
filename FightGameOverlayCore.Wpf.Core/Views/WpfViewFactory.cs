using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;

namespace FightGameOverlayCore.Wpf.Views
{
    internal class WpfViewFactory : IViewFactory
    {
        public IChangeLayoutView GetChangeLayoutView(IChangeLayoutController controller)
        {
            return new ChangeLayoutView(controller);
        }

        public IDataManagerView GetDataManagerView(IDataManagerController controller)
        {
            return new DataManagerView(controller);
        }

        public ILayoutConfigurationView GetLayoutConfigurationView(ILayoutController controller)
        {
            return new LayoutConfigurationView(controller);
        }

        public IOverlayView GetOverlayView(IOverlayController controller)
        {
            return new OverlayView(controller);
        }
    }
}
