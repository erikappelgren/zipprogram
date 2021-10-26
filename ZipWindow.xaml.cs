using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ZipWindow.xaml
    /// </summary>
    public partial class ZipWindow : Page
    {
        public ListBox lbFiles { get; set; }
        public ZipWindow(ListBox lbFiles)
        {
            this.lbFiles = lbFiles;
            InitializeComponent();
        }

        private void openFolderButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog().GetValueOrDefault())
            {
                folderLocationText.Text = dialog.SelectedPath;
            }
        }

        //zip selected files
        private void btnZip_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object item in lbFiles.SelectedItems)
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }

            string command = "-v " + newZipFolderName.Text + " " + sb.ToString();

            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = folderLocationText.Text;
            startInfo.FileName = @"C:\Users\erika\OneDrive\Dokument\molk.exe";
            startInfo.Arguments = command;
            Process proc = Process.Start(startInfo);

            ProgressWindow p = new ProgressWindow();
            p.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            p.Show();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }
    }
}
