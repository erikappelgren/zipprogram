﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
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
    /// Interaction logic for ProgressWindow.xaml
    /// </summary>
    public partial class ProgressWindow : Window
    {
		public ProgressWindow()
		{ 
			InitializeComponent();
        }

		private void Window_ContentRendered(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;

			worker.RunWorkerAsync();
		}

		public void ZipOrUnzip(int choice)
        {
			if(choice == 1)
            {
				Zipping.Content = "Unzipping your files...";
            }

        }
		void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 101; i++)
			{
				(sender as BackgroundWorker).ReportProgress(i);
				Thread.Sleep(15);
				if (i == 100)
				{
					Dispatcher.Invoke(() => {
						Close();
					});
				}
			}
		}

		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			pbStatus.Value = e.ProgressPercentage;
		}
	}
}
