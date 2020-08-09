using System.Windows;

namespace FightGameOverlayCore.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var application = new FightGameOverlayManager();
            application.Configure();
            application.Start();
        }
    }
}
