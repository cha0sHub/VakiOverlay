using FightGameOverlayCore.Interfaces.Configuration;

namespace FightGameOverlayCore.Interfaces
{
    public interface IFightGameOverlayManager
    {
        void DisplayChangeLayoutWindow();
        void DisplayAddNewLayoutWindow();
        void DisplayEditLayoutWindow(ILayoutConfiguration layoutConfiguration);
        void ShutdownApplication();
    }
}
