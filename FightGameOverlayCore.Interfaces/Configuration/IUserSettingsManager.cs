namespace FightGameOverlayCore.Interfaces.Configuration
{
    public interface IUserSettingsManager
    {
        string CurrentLayout { get; set; }
        void Initialize();
    }
}
