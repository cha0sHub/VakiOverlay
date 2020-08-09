using FightGameOverlayCore.Interfaces;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Models;
using FightGameOverlayCore.Interfaces.Views;

namespace FightGameOverlayCore.Controllers
{
    internal class DataManagerController : IDataManagerController
    {
        public IMatchModel MatchModel { get; }
        private IViewFactory ViewFactory { get; }
        private IFightGameOverlayManager FightGameOverlayManager { get; }

        private IDataManagerView DataManagerView { get; set; }

        public DataManagerController(IMatchModel matchModel, IViewFactory viewFactory, IFightGameOverlayManager fightGameOverlayManager)
        {
            MatchModel = matchModel;
            ViewFactory = viewFactory;
            FightGameOverlayManager = fightGameOverlayManager;
        }

        public void Display()
        {
            DataManagerView = ViewFactory.GetDataManagerView(this);
            DataManagerView.Display();
        }

        public void CloseWindow()
        {
            FightGameOverlayManager.ShutdownApplication();
        }

        public void Update()
        {
            MatchModel.DisplayedNamePlayerOne = MatchModel.CurrentNamePlayerOne;
            MatchModel.DisplayedNamePlayerTwo = MatchModel.CurrentNamePlayerTwo;
            MatchModel.DisplayedWinsPlayerOne = MatchModel.CurrentWinsPlayerOne;
            MatchModel.DisplayedWinsPlayerTwo = MatchModel.CurrentWinsPlayerTwo;
            MatchModel.DisplayedTournamentRound = MatchModel.CurrentTournamentRound;
        }

        public void IncrementWinsOne()
        {
            MatchModel.CurrentWinsPlayerOne += 1;
            MatchModel.DisplayedWinsPlayerOne = MatchModel.CurrentWinsPlayerOne;
        }

        public void IncrementWinsTwo()
        {
            MatchModel.CurrentWinsPlayerTwo += 1;
            MatchModel.DisplayedWinsPlayerTwo = MatchModel.CurrentWinsPlayerTwo;
        }

        public void SwapNames()
        {
            var nameOne = MatchModel.CurrentNamePlayerOne;
            var nameTwo = MatchModel.CurrentNamePlayerTwo;
            MatchModel.CurrentNamePlayerOne = nameTwo;
            MatchModel.CurrentNamePlayerTwo = nameOne;
            MatchModel.DisplayedNamePlayerOne = MatchModel.CurrentNamePlayerOne;
            MatchModel.DisplayedNamePlayerTwo = MatchModel.CurrentNamePlayerTwo;
        }

        public void ChangeLayout()
        {
            FightGameOverlayManager.DisplayChangeLayoutWindow();
        }
    }
}
