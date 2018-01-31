using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrypKey.Core
{
    /// <summary>
    /// A password entry.
    /// </summary>
    public class PasswordEntry
    {
        string password;
        string website;
        string note;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="password">Password to remember.</param>
        /// <param name="website">Website linked to the password.</param>
        /// <param name="note">Note for various things.</param>
        public PasswordEntry(string password, string website, string note)
        {
            this.password = password;
            this.website = website;
            this.note = note;
        }

        /// <summary>
        /// Get or set the password of the entry.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Get or set the website of the entry.
        /// </summary>
        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        /// <summary>
        /// Get or set the note of the entry.
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
