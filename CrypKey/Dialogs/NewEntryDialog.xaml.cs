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
    /// Dialog for a new entry.
    /// </summary>
    public partial class NewEntryDialog : Window
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public NewEntryDialog()
        {
            InitializeComponent();
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
