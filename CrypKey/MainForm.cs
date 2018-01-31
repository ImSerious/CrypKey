using CrypKey.Dialogs;
using System.Windows.Forms;

namespace CrypKey
{
    /// <summary>
    /// Main form of the software.
    /// </summary>
    public partial class MainForm : Form
    {
        string pathFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// When the user click on the "Open" button.
        /// </summary>
        private void OpenClick(object sender, System.EventArgs e)
        {
            // Create the dialog to get the file
            OpenFileDialog dialog = new OpenFileDialog();

            // If the dialog is validated by the user
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Save the file path
                pathFile = textBoxFilePath.Text = dialog.FileName;

                // Enable button since we got a file
                buttonSave.Enabled = buttonSettings.Enabled = true;

                // Create the dialog to get the password
                PasswordDialog passwordDialog = new PasswordDialog();

                // IF the dialog is validated by the user
                if (passwordDialog.ShowDialog() == DialogResult.OK)
                {
                    string password = passwordDialog.Password;
                }
            }
        }

        /// <summary>
        /// When the user click on the "Save" button.
        /// </summary>
        private void SaveClick(object sender, System.EventArgs e)
        {
            
        }

        /// <summary>
        /// When the user click on the "Settings" button.
        /// </summary>
        private void SettingsClick(object sender, System.EventArgs e)
        {

        }
    }
}
