using FightGameOverlayCore.Interfaces;
using FightGameOverlayCore.Interfaces.Configuration;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Models;
using FightGameOverlayCore.Interfaces.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FightGameOverlayCore.Controllers
{
    internal class OverlayController :INotifyPropertyChanged, IOverlayController
    {
        
        private ILayoutConfiguration _overlayConfiguration;

        public ILayoutConfiguration OverlayConfiguration
        {
            get 
            {
                return _overlayConfiguration;
            }
            set
            {
                _overlayConfiguration = value;
                NotifyPropertyChanged();
            }
        }

        public IMatchModel MatchModel { get;  }
        private IViewFactory ViewFactory { get; }
        private IFightGameOverlayManager FightGameOverlayManager { get; }
        private ILayoutManager LayoutManager { get; }

        private IOverlayView OverlayView { get; set; }

        public OverlayController(IMatchModel matchModel, IViewFactory viewFactory, IFightGameOverlayManager fightGameOverlayManager, ILayoutManager layoutManager) 
        {
            MatchModel = matchModel;
            ViewFactory = viewFactory;
            FightGameOverlayManager = fightGameOverlayManager;
            LayoutManager = layoutManager;
            OverlayConfiguration = LayoutManager.CurrentLayout;
            LayoutManager.LayoutChanged += LayoutManager_LayoutChanged;
        }

        private void LayoutManager_LayoutChanged(object sender, System.EventArgs e)
        {
            OverlayConfiguration = LayoutManager.CurrentLayout;
        }

        public void Display()
        {
            OverlayView = ViewFactory.GetOverlayView(this);
            OverlayView.Display();
        }

        public void CloseWindow()
        {
            FightGameOverlayManager.ShutdownApplication();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
