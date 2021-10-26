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

        private void MouseDownOnWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void xButtonClick(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ChangeView(new MainPage());
        }

        public void ChangeView(Page view)
        {
            MainFrame.NavigationService.Navigate(view);
        }  
    }
}
