using FightGameOverlayCore.Interfaces.Configuration;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;

namespace FightGameOverlayCore.Controllers
{
    internal class LayoutController : ILayoutController
    {
        public ILayoutConfiguration Layout { get; set; }

        private ILayoutManager LayoutManager { get; }
        private IViewFactory ViewFactory { get; }

        private ILayoutConfigurationView LayoutConfigurationView { get; set; }

        public LayoutController(ILayoutManager layoutManager, IViewFactory viewFactory)
        {
            LayoutManager = layoutManager;
            ViewFactory = viewFactory;
        }

        public void Display()
        {
            LayoutConfigurationView = ViewFactory.GetLayoutConfigurationView(this);
            LayoutConfigurationView.Display();
        }

        public void SaveLayout()
        {
            LayoutManager.SaveLayout(Layout);
            LayoutConfigurationView.CloseWindow();
        }

        public void Cancel()
        {
            LayoutConfigurationView.CloseWindow();
        }
    }
}
