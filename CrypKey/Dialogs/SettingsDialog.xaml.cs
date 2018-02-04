using CrypKeyWPF.Core;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace CrypKeyWPF.Dialogs
{
    /// <summary>
    /// Dialog for settings.
    /// </summary>
    public partial class SettingsDialog : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public SettingsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display the settings of the file.
        /// </summary>
        /// <param name="file">Current password file.</param>
        public void Display(PasswordFile file)
        {
            textBoxMasterPassword.Text = file.Password;
            textBoxNote.Text = file.Note;
        }

        /// <summary>
        /// Click on OK button.
        /// </summary>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Click on Cancel button.
        /// </summary>
        private void CancelClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Get the master password.
        /// </summary>
        public string MasterPassword
        {
            get { return textBoxMasterPassword.Text; }
        }

        /// <summary>
        /// Get the note.
        /// </summary>
        public string Note
        {
            get { return textBoxNote.Text; }
        }
    }
}
