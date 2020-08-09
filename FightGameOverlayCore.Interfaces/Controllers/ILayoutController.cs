using FightGameOverlayCore.Interfaces.Configuration;

namespace FightGameOverlayCore.Interfaces.Controllers
{
    public interface ILayoutController
    {
        ILayoutConfiguration Layout { get; set; }

        void Display();
        void SaveLayout();
        void Cancel();
    }
}
