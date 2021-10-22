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
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            ZipWindow p = new ZipWindow(lbFiles);
            //myFrameInCurrentWindow.Navigate(p);
            this.Content = p;
        }

        private void xButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*
        private void OpenFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                PreviewBox.Text = System.IO.Path.GetFileName(openFileDialog.FileName);
                FilePath.Text = openFileDialog.FileName;
            }
        }
        */

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        //select the files to be zipped
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
