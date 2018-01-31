using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrypKey.Cryptography
{
    class Tests
    {
        public void Test()
        {
            // Tirage aléa pour les nombres premiers
            Random NumberFirst = new Random();
            int P = 0;
            int Q = 0;

            bool a = true;
            // Tirage de P
            do
            {
                int Number = NumberFirst.Next(0, 100);

                if (Premier(Number))
                {
                    P = Number;
                    Console.WriteLine("P = " + P);
                    break;
                }
                else
                {
                    a = false;
                }
            }
            while (!a);
            // Tirage de Q
            do
            {
                int NumberTwo = NumberFirst.Next(0, 100);

                if (Premier(NumberTwo))
                {
                    Q = NumberTwo;
                    Console.WriteLine("Q = " + Q);
                    break;
                }
                else
                {
                    a = false;
                }
            }
            while (!a);

            // Obtention de N
            int N = P * Q;
            Console.WriteLine("N produit de P et de Q = " + N);

            // Determination du plus petit en P et Q
            int PlusPetit = 0;
            int PlusGrand = 0;
            if (P < Q)
            {
                PlusPetit = P;
                PlusGrand = Q;
            }
            else
            {
                PlusPetit = Q;
                PlusGrand = P;
            }
            //Calcul de rhoN
            int rhoN = (P - 1) * (Q - 1);
            Console.WriteLine("RhoN = " + rhoN);
            // Obtention de E entre les bornes P||Q et rhoN
            int E = 0;
            do
            {
                int Number = NumberFirst.Next(PlusPetit, rhoN);

                if (Premier(Number))
                {
                    E = Number;
                    Console.WriteLine("E = " + E);
                    break;
                }
                else
                {
                    a = false;
                }
            }
            while (!a);

            // Clef publique (E, N)
            //Calcul de D
            int D = modInverse(E, rhoN);
            Console.WriteLine("D = " + D);
            // Clef privé (D,N)

            // message en nombre 
            List<double> encodage = new List<double>();
            Encoding enc = Encoding.GetEncoding("us-ascii",
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());

            string value = "test";

            byte[] bytes = enc.GetBytes(value);
            foreach (var byt in bytes)
            {

                encodage.Add((Math.Pow(byt, E) % N));
                Console.WriteLine(encodage);
            }
            string value2 = enc.GetString(bytes);
            Console.WriteLine(value2);
        }


        public static int modInverse(int ac, int n)
        {
            int i = n, v = 0, d = 1;
            while (ac > 0)
            {
                int t = i / ac, x = ac;
                ac = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= n;
            if (v < 0) v = (v + n) % n;
            return v;
        }

        public static int NombreFacteur(int n)
        {
            int Count = 2;
            int i;
            double Racine = Math.Sqrt(n);
            for (i = 2; i <= Racine; i++)
            {
                if (n % i == 0) Count++;
            }
            return Count;
        }

        public static bool Premier(int N)
        {
            return (NombreFacteur(N) == 2);
        }
    }
}
