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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            Loaded += OnMainWindowLoaded;
        }
        private void MolkButton(object sender, RoutedEventArgs e)
        {
            try
            {
                PopupMessage Msg = new PopupMessage();
                if (lbFiles.SelectedIndex != -1 )
                {
                    ZipWindow p = new ZipWindow(lbFiles);
                    //myFrameInCurrentWindow.Navigate(p);
                    this.Content = p;
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
            App.Current.Shutdown();


        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ChangeView(new MainPage());
        }

        public void ChangeView(Page view)
        {
            MainFrame.NavigationService.Navigate(view);
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

        private void MouseDownOnWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
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
