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
            ProgressWindow p = new ProgressWindow();
            p.Show();
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
            MessageBox.Show(sb.ToString());

            string command = "-v " + "Test10.molk " + sb.ToString();
            MessageBox.Show(command);

            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Users\Olivi\source\repos";
            startInfo.FileName = @"C:\Users\Olivi\source\repos\zipprogram\molk.exe";
            //startInfo.Arguments = @"-v Test8.molk *.txt";
            startInfo.Arguments = command;
            Process proc = Process.Start(startInfo);

        }
    }
}
