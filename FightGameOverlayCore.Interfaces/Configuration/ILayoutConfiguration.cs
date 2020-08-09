namespace FightGameOverlayCore.Interfaces.Configuration
{
    public interface ILayoutConfiguration
    {
        string BackgroundColor { get; set; }
        bool DisplayRound { get; set; }
        bool DisplayWins { get; set; }
        string ImageName { get; set; }
        string LayoutName { get; set; }
        double OutsideOverlayMargin { get; set; }
        double OverlayHeight { get; set; }
        string PlayerFont { get; set; }
        bool PlayerFontBolded { get; set; }
        string PlayerFontColor { get; set; }
        bool PlayerFontItalicized { get; set; }
        double PlayerFontSize { get; set; }
        string RoundFont { get; set; }
        bool RoundFontBolded { get; set; }
        string RoundFontColor { get; set; }
        bool RoundFontItalicized { get; set; }
        double RoundFontSize { get; set; }
        double RoundNameWidth { get; set; }
        double WindowHeight { get; set; }
        double WindowWidth { get; set; }
        string WinsFont { get; set; }
        bool WinsFontBolded { get; set; }
        string WinsFontColor { get; set; }
        bool WinsFontItalicized { get; set; }
        double WinsFontSize { get; set; }
        double WinsWidth { get; set; }
        ILayoutConfiguration Copy();
    }
}