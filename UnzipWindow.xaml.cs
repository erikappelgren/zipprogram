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
    /// Interaction logic for UnzipWindow.xaml
    /// </summary>
    public partial class UnzipWindow : Page
    {
        public ListBox lbFiles { get; set; }

        public UnzipWindow(ListBox lbFiles)
        {
            this.lbFiles = lbFiles;
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

        //Unzip selected files
        private void btnUnzip_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object item in lbFiles.SelectedItems)
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }

            string command = "-j " + sb.ToString() + "-d " + filesLocationText.Text;

            var startInfo = new ProcessStartInfo();
            //startInfo.WorkingDirectory = folderLocationText.Text;

            startInfo.FileName = @"C:\Users\olivi\source\repos\zipprogram\molk.exe";

            startInfo.Arguments = command;

            Process proc = Process.Start(startInfo);

            ProgressWindow p = new ProgressWindow();
            p.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            p.ZipOrUnzip(1);
            p.Show();
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new MainPage());
        }

        private void xButtonClick(object sender, RoutedEventArgs e)
        {
            ExitConfirmation exit = new ExitConfirmation();
            exit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            exit.Show();
        }
    }
}
