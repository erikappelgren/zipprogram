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

namespace zipprogram
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                PopupMessage Msg = new PopupMessage();
                if (lbFiles.SelectedIndex != -1)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new ZipWindow(lbFiles));
                }
                else
                {
                    Msg.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    Msg.Show();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void xButtonClick(object sender, RoutedEventArgs e)
        {
            ExitConfirmation exit = new ExitConfirmation();
            exit.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            exit.Show();
        }

        //select the files to be zipped
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            //var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            //if (dialog.ShowDialog().GetValueOrDefault())
            //{
            //    string[] fileArray = Directory.GetFiles(dialog.SelectedPath);
            //    foreach (string s in fileArray)
            //    {
            //        lbFiles.Items.Add(System.IO.Path.GetFullPath(s));
            //        FilePath.Text = dialog.SelectedPath;
            //    }
            //}

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                    lbFiles.Items.Add(System.IO.Path.GetFullPath(filename));
                FilePath.Text = openFileDialog.FileName;
            }
        }

        
        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbAllFeatures.IsChecked == true);

            foreach (var item in lbFiles.Items)
            {
                ListBoxItem lbi = lbFiles.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                CheckBox cb = FindVisualChild<CheckBox>(lbi);
                if (cb != null)
                    cb.IsChecked = newVal;
            }
        }

        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;
            bool allIsChecked = true;

            foreach (var item in lbFiles.Items)
            {
                ListBoxItem lbi = lbFiles.ItemContainerGenerator.ContainerFromItem(item) as ListBoxItem;
                CheckBox cb = FindVisualChild<CheckBox>(lbi);
                if (cb.IsChecked == true && allIsChecked == true)
                {
                    allIsChecked = true;
                }
                else
                {
                    allIsChecked = false;
                }
            }
            cbAllFeatures.IsChecked = allIsChecked;
        }

        private void UnzipClick(object sender, RoutedEventArgs e)
        {
            try
            {
                PopupMessage Msg = new PopupMessage();
                if (lbFiles.SelectedIndex != -1)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new UnzipWindow(lbFiles));
                }
                else
                {
                    Msg.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    Msg.Show();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class File
    {
        public string _Name { get; set; }
        public bool _IsChecked { get; set; }

        public File(string Name, bool IsChecked)
        {
            this._Name = Name;
            this._IsChecked = IsChecked;

        }
    }
}
