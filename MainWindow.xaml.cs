using FolderIconSetter.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace FolderIconSetter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IconSetter iconSetter;
        public MainWindow()
        {
            InitializeComponent();
            iconSetter = new IconSetter();
            this.DataContext = iconSetter;
        }


        private void titleBarClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void openFolderSelector(object sender, RoutedEventArgs e)
        {
            iconSetter.FolderSelector();
        }

        private void openIconSelector(object sender, RoutedEventArgs e)
        {
            iconSetter.IconSelector();
        }

        private void openGithub(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                Process.Start("https://github.com/rahulps1000/FolderIconSetter");
            }
        }
    }
}
