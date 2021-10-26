using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zipprogram
{
    /// <summary>
    /// Interaction logic for UnzipWindow.xaml
    /// </summary>
    public partial class UnzipWindow : Page
    {
        public UnzipWindow()
        {
            InitializeComponent();
        }
        private void openFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                filesLocationText.Text = dialog.SelectedPath;
            }
        }
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressWindow p = new ProgressWindow();
            p.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            p.Show();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }
    }
}
