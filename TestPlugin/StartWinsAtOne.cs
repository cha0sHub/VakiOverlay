using FightGameOverlayCore.Interfaces.Models;
using FightGameOverlayCore.Interfaces.PluginSupport;

namespace TestPlugin
{
    public class StartWinsAtOne : IPlugin
    {
        private IMatchModel MatchModel { get; }

        public StartWinsAtOne(IMatchModel matchModel)
        {
            MatchModel = matchModel;
        }

        public void Shutdown()
        {

        }

        public void Start()
        {
            MatchModel.CurrentWinsPlayerOne = 1;
            MatchModel.CurrentWinsPlayerTwo = 1;
            MatchModel.DisplayedWinsPlayerOne = 1;
            MatchModel.DisplayedWinsPlayerTwo = 1;
        }
    }
}
