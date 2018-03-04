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
        private string[] TabAlphabetMaj;
        private string[] TabAlphabetMin;
        private int[] TabNumber;
        private List<string> words;
        private List<int> idValueWords;

        
        

        /// <summary>
        /// Constructor
        /// </summary>
        public Cryptography()
        {
            TabAlphabetMaj = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            TabAlphabetMin = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            TabNumber = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            words = new List<string>();
            idValueWords = new List<int>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        /// <returns>wordsEncrypt is word encrypted with separated point</returns>
        public string ConvertInput(SettingsDialog entry)
        {
            int[] PasswordMaster = new int[] { 1, 2, 3, 4, 5 ,6};
            List<string> PasswordCrypt = new List<string>();
            // Erreur de saisie
            bool error = true;

            // Boucle d'erreur de saisie
            do
            {
                // Récupération du mot de passe
                string input = entry.MasterPassword;
                
                try
                {
                    // Convert password in numbers
                    foreach (char c in input)
                    {
                        int a = System.Convert.ToInt32(c);
                        idValueWords.Add(a);
                        error = false;
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
                    words.Clear();
                    error = true;
                    MessageBox.Show("Erreur inattendue, veuillez recommencer!");
                } 
            }
            while (error == true);
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
            int[] PasswordMaster = new int[] { 1, 2, 3, 4, 5, 6 };
            List<int> decryptPassword = new List<int>();
            List<string> PasswordCrypt = new List<string>();
            PasswordEntry wordsCrypted = new PasswordEntry(cryptedEntry, web, note);

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
                    int result = decryptPassword[i] + PasswordMaster[pass];
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
            wordsCrypted.Password = string.Join("", PasswordCrypt.ToArray());
            return wordsCrypted;
        }
    }
}
