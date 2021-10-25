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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressWindow p = new ProgressWindow(lbFiles);
            p.Show();
        }

        //zip selected files
        private void btnZip_Click(object sender, RoutedEventArgs e)
        {
            //ProgressBar pbStatus = new ProgressBar();
            //pbStatus.Visibility = Visibility.Visible;
            //pbStatus.IsIndeterminate = true;

            //pbStatus.Visibility = Visibility.Visible;
            //pbStatus.IsIndeterminate = true;

            StringBuilder sb = new StringBuilder();
            foreach (object item in lbFiles.SelectedItems)
            {
                sb.Append(item.ToString());
                sb.Append(" ");
            }

            string command = "-v " + newZipFolderName.Text + " " + sb.ToString();

            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = folderLocationText.Text;
            startInfo.FileName = @"C:\Users\Olivi\source\repos\zipprogram\molk.exe";
            startInfo.Arguments = command;
            Process proc = Process.Start(startInfo);

            //pbStatus.Visibility = Visibility.Collapsed;
            //proc.StandardOutput.ReadToEnd();

        }
    }
}
