using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace zipprogram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            /*
            List<File> files = new List<File>();
            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                files.Add(new File(Name) { Name = lbFiles[i]});
            }
            lbFiles.ItemsSource = files;
            */
        }

        /*
        private void OpenFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            if (openFileDialog.ShowDialog() == true)
            {
                PreviewBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
        */

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    lbFiles.Items.Add(System.IO.Path.GetFileName(filename));
                FilePath.Text = openFileDialog.FileName;
            }
        }

        
        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbAllFeatures.IsChecked == true);

            for (int i = 0; i < lbFiles.Items.Count; i++)
            {
                CheckBox item = lbFiles.Items[i] as CheckBox;
                item.IsChecked = newVal;
            }
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;

            foreach (CheckBox item in lbFiles.Items)
            {
                if ((item.IsChecked == true))
                {
                    cbAllFeatures.IsChecked = true;
                }
                else if ((item.IsChecked == false))
                {
                    cbAllFeatures.IsChecked = false;
                }
            }
        }

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

    public class File
    {
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        
        public File(string Name, bool IsChecked)
        {
            this.Name = Name;
            this.IsChecked = IsChecked;
        }
    }
}
