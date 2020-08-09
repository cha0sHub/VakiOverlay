using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;
using System.Windows;

namespace FightGameOverlayCore.Wpf.Views
{
    /// <summary>
    /// Interaction logic for LayoutConfigurationView.xaml
    /// </summary>
    public partial class LayoutConfigurationView : Window, ILayoutConfigurationView
    {

        private ILayoutController Controller { get; }

        public LayoutConfigurationView(ILayoutController controller)
        {
            Controller = controller;
            DataContext = controller;
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.SaveLayout();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.Cancel();
        }

        public void Display()
        {
            ShowDialog();
        }

        public void CloseWindow()
        {
            Close();
        }

    }
}
