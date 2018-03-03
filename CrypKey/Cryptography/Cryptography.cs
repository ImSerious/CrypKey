using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrypKeyWPF.Core;
using CrypKeyWPF.Dialogs;
using System.Windows.Input;

namespace CrypKeyWPF.Cryptography
{
    public class Cryptography
    {
        string[] TabAlphabetMaj;
        string[] TabAlphabetMin;
        int[] TabNumber;
        List<string> words;
        List<int> idValueWords;

        /// <summary>
        /// 
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
        public void UserInput()
        {
            // Erreur de saisie
            bool error = true;

            // Boucle d'erreur de saisie
            do
            {
                // Saisie du mot de passe
                Console.WriteLine("Veuillez saisir password");
                string input = Console.ReadLine();

                // Pour chaques lettres, les stocker dans la liste de lettre de mot
                for (int i = 0; i < input.Length; i++)
                {
                    words.Add(input.Substring(i, 1)); // Récup à i , une lettre
                }

                // Pour chaque lettre ou nombre de la liste, recuperer l'emplacement par rapport à la liste alphabet
                for (int i = 0; i < words.Count; i++)
                {
                    bool choice = false; // Si true = lettre, si false = nombre

                    try
                    {
                        for (int o = 0; o < TabAlphabetMin.Length; o++)
                        {
                            if (words[i] == TabAlphabetMin[o])
                            {
                                idValueWords.Add(o + 1);
                                choice = true;
                                error = false;
                                break;
                            }
                        }
                        for (int o = 0; o < TabAlphabetMaj.Length; o++)
                        {
                            if (words[i] == TabAlphabet[o])
                            {
                                idValueWords.Add(o + 1);
                                choice = true;
                                error = false;
                                break;
                            }
                        }
                        if (choice == false)
                        {
                            for (int a = 0; a < 10; a++)
                            {
                                if (Convert.ToInt32(words[i]) == TabNumber[a])
                                {
                                    idValueWords.Add(TabNumber[a]);
                                    error = false;
                                    break;
                                }
                            }
                        }
                    }
                    catch
                    {
                        words.Clear();
                        error = true;
                        Console.WriteLine("Veuillez saisir uniquement des chiffres et des lettres, caractères spéciaux interdits");
                    }
                }
            }
            while (error == true);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Encryption()
        {
            int[] PasswordMaster = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            List<int> PasswordCrypt = new List<int>();
            int pass = 0;
            for (int i = 0; i < idValueWords.Count; i++)
            {
                if (pass <= 5)
                {
                    int result = PasswordMaster[pass] + idValueWords[i];
                    PasswordCrypt.Add(result);
                    pass++;
                }
                else
                {
                    pass = 0;
                    int result = PasswordMaster[pass] + idValueWords[i];
                    PasswordCrypt.Add(result);
                    pass++;
                }
            }

            Console.WriteLine("Chiffré : ");
            foreach (int val in PasswordCrypt)
            {
                Console.Write(val + " ");
            }
        }

        /// <summary>
        /// /
        /// </summary>
        public void decryption()
        {

        }
    }
}
