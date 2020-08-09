using FightGameOverlayCore.Interfaces.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FightGameOverlayCore.Configuration
{
    internal class LayoutManager : ILayoutManager
    {
        private string LayoutPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Layouts/");

        public event EventHandler LayoutChanged;

        public event EventHandler LayoutAddedOrModified;

        private Dictionary<string, ILayoutConfiguration> LayoutConfigurations { get; }

        public IEnumerable<ILayoutConfiguration> AvailableLayouts => LayoutConfigurations.Values;

        public ILayoutConfiguration CurrentLayout
        {
            get
            {
                if (!LayoutConfigurations.ContainsKey(UserSettingsManager.CurrentLayout))
                {
                    var firstLayoutName = LayoutConfigurations.Keys.First();
                    UserSettingsManager.CurrentLayout = firstLayoutName;
                }

                return LayoutConfigurations[UserSettingsManager.CurrentLayout];
            }
            set
            {
                if (LayoutConfigurations.ContainsKey(value.LayoutName))
                {
                    UserSettingsManager.CurrentLayout = value.LayoutName;
                    LayoutChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        private IUserSettingsManager UserSettingsManager { get; }

        public LayoutManager(IUserSettingsManager userSettingsManager)
        {
            UserSettingsManager = userSettingsManager;
            LayoutConfigurations = new Dictionary<string, ILayoutConfiguration>();
        }

        public void DiscoverLayouts()
        {
            var layoutFiles = Directory.GetFiles(LayoutPath, "*.json");
            foreach (var file in layoutFiles)
            {
                var layoutData = string.Empty;
                using (var streamReader = File.OpenText(file))
                {
                    layoutData = streamReader.ReadToEnd();
                }
                try
                {
                    var layoutConfiguration = JsonConvert.DeserializeObject<LayoutConfiguration>(layoutData);
                    if (!LayoutConfigurations.ContainsKey(layoutConfiguration.LayoutName))
                    {
                        LayoutConfigurations.Add(layoutConfiguration.LayoutName, layoutConfiguration);
                    }
                }
                catch (JsonException)
                { 
                    //could not parse layout file, log at some point
                }
            }
        }

        public void SaveLayout(ILayoutConfiguration layoutConfiguration)
        {
            if (LayoutConfigurations.ContainsKey(layoutConfiguration.LayoutName))
            {
                LayoutConfigurations[layoutConfiguration.LayoutName] = layoutConfiguration;
            }
            else
            {
                LayoutConfigurations.Add(layoutConfiguration.LayoutName, layoutConfiguration);
            }

            var layoutFilePath = Path.Combine(LayoutPath, $"{layoutConfiguration.LayoutName}.json");
            var layoutData = JsonConvert.SerializeObject((LayoutConfiguration)layoutConfiguration);
            using (var streamWriter = File.CreateText(layoutFilePath))
            {
                streamWriter.Write(layoutData);
            }
            LayoutAddedOrModified?.Invoke(this, EventArgs.Empty);
        }
    }
}
