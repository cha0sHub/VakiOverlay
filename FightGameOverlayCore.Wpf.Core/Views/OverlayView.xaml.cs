using FightGameOverlayCore.Controllers;
using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;
using System;
using System.Windows;
using System.Windows.Input;

namespace FightGameOverlayCore.Wpf.Views
{
    /// <summary>
    /// Interaction logic for Overlay.xaml
    /// </summary>
    internal partial class OverlayView : Window, IOverlayView
    {

        private IOverlayController Controller { get; }

        public OverlayView(IOverlayController controller)
        {
            Controller = controller;
            DataContext = controller;
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Controller.CloseWindow();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        public void Display()
        {
            Show();
        }
    }
}
