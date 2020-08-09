using FightGameOverlayCore.Interfaces;
using FightGameOverlayCore.Interfaces.Configuration;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;
using System.Collections.ObjectModel;

namespace FightGameOverlayCore.Controllers
{
    internal class ChangeLayoutController : IChangeLayoutController
    {
        public ILayoutConfiguration SelectedLayoutConfiguration { get; set; }
        public ILayoutManager LayoutManager { get; }
        private IFightGameOverlayManager FightGameOverlayManager { get; }
        private IViewFactory ViewFactory { get; }
        private IChangeLayoutView ChangeLayoutView { get; set; }

        public ObservableCollection<ILayoutConfiguration> AvailableConfigurations { get; }

        public ChangeLayoutController(ILayoutManager layoutManager, IFightGameOverlayManager fightGameOverlayManager, IViewFactory viewFactory)
        {
            AvailableConfigurations = new ObservableCollection<ILayoutConfiguration>();
            LayoutManager = layoutManager;
            FightGameOverlayManager = fightGameOverlayManager;
            ViewFactory = viewFactory;
            LayoutManager.LayoutAddedOrModified += LayoutManager_LayoutAddedOrModified;
            BuildList();
        }

        private void BuildList()
        {
            AvailableConfigurations.Clear();
            foreach (var layout in LayoutManager.AvailableLayouts)
            {
                AvailableConfigurations.Add(layout);
            }
        }

        private void LayoutManager_LayoutAddedOrModified(object sender, System.EventArgs e)
        {
            BuildList();
        }

        public void AddNewLayout()
        {
            FightGameOverlayManager.DisplayAddNewLayoutWindow();
        }

        public void EditLayout()
        {
            if (SelectedLayoutConfiguration == null)
            {
                return;
            }

            FightGameOverlayManager.DisplayEditLayoutWindow(SelectedLayoutConfiguration);
        }

        public void ApplyLayout()
        {
            if (SelectedLayoutConfiguration == null)
            {
                return;
            }

            LayoutManager.CurrentLayout = SelectedLayoutConfiguration;
        }

        public void Display()
        {
            ChangeLayoutView = ViewFactory.GetChangeLayoutView(this);
            ChangeLayoutView.Display();
        }

        public void CloseWindow()
        {
            WindowClosing();
            ChangeLayoutView.CloseWindow();
        }

        public void WindowClosing()
        {
            LayoutManager.LayoutAddedOrModified -= LayoutManager_LayoutAddedOrModified;
        }
    }
}
