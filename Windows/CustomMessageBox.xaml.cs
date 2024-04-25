using FolderIconSetter.Models;
using System;
using System.Diagnostics;
using System.Web;
using System.Windows;
using System.Windows.Input;

namespace FolderIconSetter.Windows
{
    /// <summary>
    /// Interaction logic for CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {

        MessageBoxModel messagebox;
        private Exception exception;
        public CustomMessageBox()
        {
            InitializeComponent();
            messagebox = new MessageBoxModel(); 
            this.DataContext = messagebox;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
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

        public void Show(String title, String message)
        {
            messagebox.Title = title;
            messagebox.Error = null;
            messagebox.Message = message;
            this.ShowDialog();
        }

        public void Show(String title, Exception error)
        {
            messagebox.Title = title;
            messagebox.Error = error.Message;
            this.exception = error;
            this.ShowDialog();
        }

        private void reportError(object sender, RoutedEventArgs e)
        {
            var url = "https://github.com/rahulps1000/FolderIconSetter/issues/new?labels=bug&body=";

            var body = $@"**Describe the bug**
A clear and concise description of what the bug is.

**To Reproduce**
Steps to reproduce the behavior:
1. Go to '...'
2. Click on '....'
3. Scroll down to '....'
4. See error

**Expected behavior**
A clear and concise description of what you expected to happen.

**Screenshots**
If applicable, add screenshots to help explain your problem.

**Desktop (please complete the following information):**
 - OS: [e.g. iOS]
 - Browser [e.g. chrome, safari]
 - Version [e.g. 22]

**Additional context**
Add any other context about the problem here.

**Exception**
{exception}";

            var encrypted_body = HttpUtility.UrlEncode(body);

            Process.Start(url + encrypted_body);
        }

    }
}
