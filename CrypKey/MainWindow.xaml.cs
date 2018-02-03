using CrypKeyWPF.Core;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CrypKeyWPF
{
    /// <summary>
    /// Main windows of CrypKey.
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Click on the Open button.
        /// </summary>
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                textBoxPath.Text = pathFile = dialog.FileName;

                buttonAdd.IsEnabled = buttonRemove.IsEnabled = buttonSave.IsEnabled = buttonSettings.IsEnabled = true; // Could be replaced by binding a check on PassworFile or filePath
            }
        }

        /// <summary>
        /// Click on the Save button.
        /// </summary>
        private void SaveClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == true)
            {

            }
        }

        /// <summary>
        /// Click on the Settings button.
        /// </summary>
        private void SettingsClick(object sender, RoutedEventArgs e)
        {
            
        }

        /// <summary>
        /// Click on a website in password entry.
        /// </summary>
        private void WebsiteClick(object sender, MouseButtonEventArgs e)
        {
            var test = (TextBlock)sender;

            Process.Start(test.Text);
        }
    }
}
