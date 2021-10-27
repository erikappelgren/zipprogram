using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace zipprogram
{
    /// <summary>
    /// Interaction logic for ExitConfirmation.xaml
    /// </summary>
    public partial class ExitConfirmation : Window
    {
        public ExitConfirmation()
        {
            InitializeComponent();
        }

        private void noButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void yesButton(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
