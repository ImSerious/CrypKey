using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrypKeyWPF.Core;
using CrypKeyWPF.Dialogs;
using System.Windows.Input;
using System.Windows;

namespace CrypKeyWPF.Cryptography
{
    public class Cryptography
    {
        // Coming soon: random key + key encryption
        // Replacement of encryption loops by six separate actions

        private List<int> idValueWords;
        private int[] PasswordMaster;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cryptography()
        {
            idValueWords = new List<int>();
            // key
            PasswordMaster = new int[] { 1, 2, 3, 4, 5, 6 };
        }

        /// <summary>
        /// Encryption method
        /// </summary>
        /// <param name="entry"></param>
        /// <returns>wordsEncrypt is word encrypted with separated point</returns>
        public string Encryption(SettingsDialog entry)
        {
            List<string> PasswordCrypt = new List<string>();

            // Recovery of value
            string input = entry.MasterPassword;

            try
            {
                // Convert password in numbers
                foreach (char i in input)
                {
                    int convertInput = System.Convert.ToInt32(i);
                    idValueWords.Add(convertInput);
                }
                // Encrypt
                int pass = 0;
                for (int i = 0; i < idValueWords.Count; i++)
                {
                    if (pass <= 5)
                    {
                        int result = PasswordMaster[pass] + idValueWords[i];
                        //Convert result in string for display only one word
                        PasswordCrypt.Add(result.ToString());
                        pass++;
                    }
                    else
                    {
                        pass = 0;
                        int result = PasswordMaster[pass] + idValueWords[i];
                        //Convert result in string for display only one word
                        PasswordCrypt.Add(result.ToString());
                        pass++;
                    }
                }
            }
            catch
            {
                idValueWords.Clear();
                MessageBox.Show("Erreur inattendue, veuillez recommencer!");
            }

            // Convert tab string in word string
            string wordsCrypted = string.Join(".", PasswordCrypt.ToArray());
            return wordsCrypted;
        }

        /// <summary>
        /// Decryption method
        /// </summary>
        /// <param name="cryptedEntry"></param>
        /// <param name="web"></param>
        /// <param name="note"></param>
        /// <param name="index"></param>
        /// <returns>word decrypted</returns>
        public PasswordEntry Decryption(string cryptedEntry,string web, string note, int index)
        {
            List<int> decryptPassword = new List<int>();
            List<string> PasswordCrypt = new List<string>();
            PasswordEntry wordsDecrypted = new PasswordEntry(cryptedEntry, web, note);

            char delimiter = '.';
            string[] substrings = cryptedEntry.Split(delimiter);
            foreach (var i in substrings)
            {
                decryptPassword.Add(Convert.ToInt32(i));
            }
            //Decrypt
            int pass = 0;
            for (int i = 0; i < decryptPassword.Count; i++)
            {
                if (pass <= 5)
                {
                    int result = decryptPassword[i] - PasswordMaster[pass];
                    //Convert result in string for display only one word
                    PasswordCrypt.Add(result.ToString());
                    pass++;
                }
                else
                {
                    pass = 0;
                    int result = decryptPassword[i] - PasswordMaster[pass] ;
                    //Convert result in string for display only one word
                    PasswordCrypt.Add(result.ToString());
                    pass++;
                }
            }
            wordsDecrypted.Password = string.Join("", PasswordCrypt.ToArray());
            return wordsDecrypted;
        }
    }
}
