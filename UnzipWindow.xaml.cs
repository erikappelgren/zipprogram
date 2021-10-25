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
                folderLocationText.Text = dialog.SelectedPath;
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

            string command = "-v " + sb.ToString() + " " + "-d " + folderLocationText.Text;
            MessageBox.Show(command);

            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = folderLocationText.Text;
            startInfo.FileName = @"C:\Users\Olivi\source\repos\zipprogram\unmolk.exe";
            startInfo.Arguments = command;

            Process proc = Process.Start(startInfo);

        }
    }
}
