using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace FightGameOverlayCore.Wpf.Views
{
    /// <summary>
    /// Interaction logic for ChangeLayoutView.xaml
    /// </summary>
    public partial class ChangeLayoutView : Window, IChangeLayoutView
    {

        private IChangeLayoutController Controller { get; }

        public ChangeLayoutView(IChangeLayoutController controller)
        {
            Controller = controller;
            DataContext = controller;
            InitializeComponent();
        }

        public void Display()
        {
            ShowDialog();
        }

        private void AddNewOverlay_Click(object sender, RoutedEventArgs e)
        {
            Controller.AddNewLayout();
        }

        private void ApplyOverlay_Click(object sender, RoutedEventArgs e)
        {
            Controller.ApplyLayout();
        }

        void IChangeLayoutView.CloseWindow()
        {
            Close();
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Controller.CloseWindow();
        }

        private void EditOverlay_Click(object sender, RoutedEventArgs e)
        {
            Controller.EditLayout();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Controller.WindowClosing();
        }
    }
}
