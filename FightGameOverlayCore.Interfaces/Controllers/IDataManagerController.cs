using FightGameOverlayCore.Interfaces.Models;

namespace FightGameOverlayCore.Interfaces.Controllers
{
    public interface IDataManagerController
    {
        IMatchModel MatchModel { get; }

        void IncrementWinsOne();
        void IncrementWinsTwo();
        void SwapNames();
        void Update();
        void ChangeLayout();
        void Display();
    }
}