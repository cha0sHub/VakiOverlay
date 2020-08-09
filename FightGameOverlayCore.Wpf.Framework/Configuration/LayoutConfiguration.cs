using FightGameOverlayCore.Interfaces.Configuration;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FightGameOverlayCore.Configuration
{
    public class LayoutConfiguration : ILayoutConfiguration
    {
        public string LayoutName { get; set; }
        public string BackgroundColor { get; set; } = "#00000000";
        public Brush BackgroundBrush => new SolidColorBrush((Color)ColorConverter.ConvertFromString(BackgroundColor));

        public double WindowHeight { get; set; } = 100;
        public double WindowWidth { get; set; } = 960;

        public double OverlayHeight { get; set; } = 42;
        public GridLength OverlayGridHeight => new GridLength(OverlayHeight);

        public double RoundNameWidth { get; set; } = 235;
        public GridLength RoundNameGridWidth => new GridLength(RoundNameWidth);

        public double OutsideOverlayMargin { get; set; } = 95;
        public GridLength OutsideOverlayGridWidth => new GridLength(OutsideOverlayMargin);

        public double WinsWidth { get; set; } = 50;

        public string PlayerFont { get; set; } = "Segoe UI Black";
        public FontFamily PlayerFontFamily => new FontFamily(PlayerFont);

        public string PlayerFontColor { get; set; } = "#FFFFFFFF";
        public Brush PlayerFontBrush => new SolidColorBrush((Color)ColorConverter.ConvertFromString(PlayerFontColor));

        public double PlayerFontSize { get; set; } = 18;

        public bool PlayerFontBolded { get; set; } = false;
        public FontWeight PlayerFontWeight => PlayerFontBolded ? FontWeights.Bold : FontWeights.Normal;

        public bool PlayerFontItalicized { get; set; } = false;
        public FontStyle PlayerFontStyle => PlayerFontItalicized ? FontStyles.Italic : FontStyles.Normal;

        public string WinsFont { get; set; } = "Segoe UI Black";
        public FontFamily WinsFontFamily => new FontFamily(WinsFont);

        public string WinsFontColor { get; set; } = "#FFFFFFFF";
        public Brush WinsFontBrush => new SolidColorBrush((Color)ColorConverter.ConvertFromString(WinsFontColor));

        public double WinsFontSize { get; set; } = 18;

        public bool WinsFontBolded { get; set; } = false;
        public FontWeight WinsFontWeight => WinsFontBolded ? FontWeights.Bold : FontWeights.Normal;

        public bool WinsFontItalicized { get; set; } = false;
        public FontStyle WinsFontStyle => WinsFontItalicized ? FontStyles.Italic : FontStyles.Normal;

        public string RoundFont { get; set; } = "Segoe UI Black";
        public FontFamily RoundFontFamily => new FontFamily(RoundFont);

        public string RoundFontColor { get; set; } = "#FFFFFFFF";
        public Brush RoundFontBrush => new SolidColorBrush((Color)ColorConverter.ConvertFromString(RoundFontColor));

        public double RoundFontSize { get; set; } = 14;

        public bool RoundFontBolded { get; set; } = false;
        public FontWeight RoundFontWeight => RoundFontBolded ? FontWeights.Bold : FontWeights.Normal;

        public bool RoundFontItalicized { get; set; } = false;
        public FontStyle RoundFontStyle => RoundFontItalicized ? FontStyles.Italic : FontStyles.Normal;

        public string ImageName { get; set; } = "overlay0.png";
        public ImageSource ImageSource => new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Images/{ImageName}")));

        public bool DisplayWins { get; set; } = true;
        public Visibility WinsVisibility => DisplayWins ? Visibility.Visible : Visibility.Collapsed;

        public bool DisplayRound { get; set; } = true;
        public Visibility RoundVisibility => DisplayRound ? Visibility.Visible : Visibility.Collapsed;

        public ILayoutConfiguration Copy()
        {
            var copyLayout = new LayoutConfiguration
            {
                BackgroundColor = BackgroundColor,
                DisplayRound = DisplayRound,
                DisplayWins = DisplayWins,
                ImageName = ImageName,
                LayoutName = LayoutName,
                OutsideOverlayMargin = OutsideOverlayMargin,
                OverlayHeight = OverlayHeight,
                PlayerFont = PlayerFont,
                PlayerFontBolded = PlayerFontBolded,
                PlayerFontColor = PlayerFontColor,
                PlayerFontItalicized = PlayerFontItalicized,
                PlayerFontSize = PlayerFontSize,
                RoundFont = RoundFont,
                RoundFontBolded = RoundFontBolded,
                RoundFontColor = RoundFontColor,
                RoundFontItalicized = RoundFontItalicized,
                RoundFontSize = RoundFontSize,
                RoundNameWidth = RoundNameWidth,
                WindowHeight = WindowHeight,
                WindowWidth = WindowWidth,
                WinsFont = WinsFont,
                WinsFontBolded = WinsFontBolded,
                WinsFontColor = WinsFontColor,
                WinsFontItalicized = WinsFontItalicized,
                WinsFontSize = WinsFontSize,
                WinsWidth = WinsWidth
            };

            return copyLayout;
        }


        public override string ToString()
        {
            return LayoutName;
        }

    }
}
