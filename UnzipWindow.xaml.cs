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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zipprogram
{
    /// <summary>
    /// Interaction logic for UnzipWindow.xaml
    /// </summary>
    public partial class UnzipWindow : Page
    {
        public UnzipWindow()
        {
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
    }
}
