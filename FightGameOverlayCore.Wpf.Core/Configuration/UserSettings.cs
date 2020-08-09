using FightGameOverlayCore.Interfaces.Configuration;

namespace FightGameOverlayCore.Configuration
{
    public class UserSettings : IUserSettings
    {
        public string CurrentLayout { get; set; }
    }
}
