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
    /// Dialog for an entry.
    /// </summary>
    public partial class EntryDialog : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public EntryDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display an entry.
        /// </summary>
        /// <param name="entry">Entry to display.</param>
        public void Display(PasswordEntry entry)
        {
            textBoxPassword.Text = entry.Password;
            textBoxNote.Text = entry.Note;
            textBoxWebsite.Text = entry.Website;
        }

        /// <summary>
        /// Click on OK button.
        /// </summary>
        private void OkClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        /// <summary>
        /// Get the password.
        /// </summary>
        public string Password
        {
            get { return textBoxPassword.Text; }
        }

        /// <summary>
        /// Get the website.
        /// </summary>
        public string Website
        {
            get { return textBoxWebsite.Text; }
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
