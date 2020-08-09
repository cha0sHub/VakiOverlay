using FightGameOverlayCore.Interfaces.Controllers;
using FightGameOverlayCore.Interfaces.Views;
using System;
using System.Windows;

namespace FightGameOverlayCore.Wpf.Views
{
    /// <summary>
    /// Interaction logic for DataManager.xaml
    /// </summary>
    internal partial class DataManagerView : Window, IDataManagerView
    {
        private IDataManagerController Controller { get; }
        public DataManagerView(IDataManagerController controller)
        {
            Controller = controller;
            DataContext = controller;
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void WinsOneButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.IncrementWinsOne();
        }

        private void WinsTwoButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.IncrementWinsTwo();
        }

        private void SwapButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.SwapNames();
        }

        private void ChangeLayoutButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.ChangeLayout();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Controller.Update();
        }

        public void Display()
        {
            Show();
        }
    }
}
