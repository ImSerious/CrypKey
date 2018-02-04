using CrypKeyWPF.Core;
using CrypKeyWPF.Dialogs;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        PasswordFile file;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the software is initializing.
        /// </summary>
        private void Initializing(object sender, EventArgs e)
        {
            file = new PasswordFile();
        }

        /// <summary>
        /// Click on the Open button.
        /// </summary>
        private void OpenClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == true)
            {
                // Save and display the complete path
                textBoxPath.Text = pathFile = dialog.FileName;
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
            SettingsDialog dialog = new SettingsDialog();

            dialog.Display(file);

            if (dialog.ShowDialog() == true)
            {
                file.Password = dialog.MasterPassword;
                file.Note = dialog.Note;
            }
        }

        /// <summary>
        /// Click on the Add button.
        /// </summary>
        private void AddClick(object sender, RoutedEventArgs e)
        {
            EntryDialog dialog = new EntryDialog();

            if (dialog.ShowDialog() == true)
            {
                PasswordEntry entry = new PasswordEntry(dialog.Password, dialog.Website, dialog.Note);

                file.Add(entry);
            }
        }

        /// <summary>
        /// Click on the Remove button.
        /// </summary>
        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            if (listViewEntries.SelectedIndex != -1)
            {
                PasswordEntry entry = listViewEntries.SelectedItem as PasswordEntry;

                file.Remove(entry);
            }

            else
            {
                MessageBox.Show("Please select an entry");
            }
        }

        /// <summary>
        /// Click on a website in password entry.
        /// </summary>
        private void WebsiteClick(object sender, MouseButtonEventArgs e)
        {
            var test = (TextBlock)sender;

            Process.Start(test.Text);
        }

        /// <summary>
        /// Double click on entries.
        /// </summary>
        private void EntriesDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (listViewEntries.SelectedIndex >= 0)
            {
                PasswordEntry entry = listViewEntries.SelectedItem as PasswordEntry;

                EntryDialog dialog = new EntryDialog();

                dialog.Display(entry);

                if (dialog.ShowDialog() == true)
                {
                    entry.Password = dialog.Password;
                    entry.Website = dialog.Website;
                    entry.Note = dialog.Note;

                    listViewEntries.ItemsSource = file.Entries.ToList();
                }
            }
        }

        /// <summary>
        /// Current file.
        /// </summary>
        public PasswordFile File
        {
            get { return file; }
        }
    }
}
