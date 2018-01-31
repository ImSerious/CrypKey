using System.Windows.Forms;

namespace CrypKey.Dialogs
{
    /// <summary>
    /// Dialog to get the password.
    /// </summary>
    public partial class PasswordDialog : Form
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PasswordDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get the password.
        /// </summary>
        public string Password
        {
            get { return textBoxPassword.Text; }
        }
    }
}
