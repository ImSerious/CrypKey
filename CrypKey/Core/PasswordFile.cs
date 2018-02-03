using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrypKeyWPF.Core
{
    /// <summary>
    /// A file that contains every entries.
    /// </summary>
    public class PasswordFile
    {
        string password;
        string note;
        List<PasswordEntry> entries;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PasswordFile()
        {
            entries = new List<PasswordEntry>();
        }

        /// <summary>
        /// Add an existing entry to the file.
        /// </summary>
        /// <param name="entry">Existing entry to add.</param>
        public void Add(PasswordEntry entry)
        {
            entries.Add(entry);
        }

        /// <summary>
        /// Add a new entry to the file.
        /// </summary>
        /// <param name="password">Password of the entry.</param>
        /// <param name="website">Website of the entry.</param>
        /// <param name="note">Note of the entry.</param>
        public void Add(string password, string website, string note)
        {
            PasswordEntry entry = new PasswordEntry(password, website, note);

            Add(entry);
        }

        /// <summary>
        /// Remove an entry from the file.
        /// </summary>
        /// <param name="entry">Entry to remove.</param>
        public void Remove(PasswordEntry entry)
        {

        }

        /// <summary>
        /// Remove an entry from the file.
        /// </summary>
        /// <param name="index">Index of the entry.</param>
        public void Remove(int index)
        {

        }

        /// <summary>
        /// Encrypt an entry.
        /// </summary>
        /// <param name="entry">Entry to encrypt.</param>
        /// <param name="index">Current index.</param>
        public string Encrypt(PasswordEntry entry,int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrypt an entry.
        /// </summary>
        /// <param name="cryptedEntry">Crypted entry.</param>
        /// <param name="index">Current index.</param>
        public PasswordEntry Decrypt(string cryptedEntry, int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Load the file from a path.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        /// <returns>Loaded password file.</returns>
        public static PasswordFile Load(string path)
        {
            PasswordFile file = null;

            return file;
        }

        /// <summary>
        /// Save the file.
        /// </summary>
        /// <param name="path">Path of the file.</param>
        public void Save(string path)
        {

        }

        /// <summary>
        /// Get or set the password of the file.
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Get or set the note of the file.
        /// </summary>
        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        /// <summary>
        /// Get the entries of the password file.
        /// </summary>
        public List<PasswordEntry> Entries
        {
            get { return entries; }
        }
    }
}
