using FightGameOverlayCore.Interfaces.Configuration;
using Newtonsoft.Json;
using System;
using System.IO;

namespace FightGameOverlayCore.Configuration
{
    internal class UserSettingsManager : IUserSettingsManager
    {
        private string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "usersettings.json");
        private UserSettings UserSettings { get; set; }

        public string CurrentLayout
        {
            get
            {
                return UserSettings.CurrentLayout;
            }
            set
            {
                UserSettings.CurrentLayout = value;
                SaveUserSettings();
            }
        }

        public UserSettingsManager()
        { 
            
        }
        public void Initialize()
        {
            LoadUserSettings();
        }

        private void LoadUserSettings()
        {
            var userData = string.Empty;
            using (var streamReader = File.OpenText(FilePath))
            {
                userData = streamReader.ReadToEnd();
            }
            try
            {
                UserSettings = JsonConvert.DeserializeObject<UserSettings>(userData);
            }
            catch (JsonException)
            {
                //failed to load user settings, reinitialize.
                UserSettings = new UserSettings();
                SaveUserSettings();
            }
        }

        private void SaveUserSettings()
        {
            var serializedData = JsonConvert.SerializeObject(UserSettings);
            using (var streamWriter = File.CreateText(FilePath))
            {
                streamWriter.Write(serializedData);
            }
        }
    }
}
