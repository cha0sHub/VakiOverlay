using FightGameOverlayCore.Interfaces.Configuration;

namespace FightGameOverlayCore.Interfaces.Controllers
{
    public interface IChangeLayoutController
    {
        ILayoutConfiguration SelectedLayoutConfiguration { get; set; }
        ILayoutManager LayoutManager { get; }

        void AddNewLayout();
        void EditLayout();
        void ApplyLayout();
        void Display();
        void CloseWindow();
        void WindowClosing();
    }
}
