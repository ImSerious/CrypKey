using System.Windows.Forms;

namespace CrypKey
{
    /// <summary>
    /// Main form of the software.
    /// </summary>
    public partial class MainForm : Form
    {
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
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
