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
        public ZipWindow()
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

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            ProgressWindow p = new ProgressWindow();
            p.Show();
        }
    }
}
