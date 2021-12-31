using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordGenerator
{
    class Program
    {
        //Zaprojektuj program kryptograficzny, który umożliwi generowanie hasła korzystającego z kodowania 3DES(Triple DES):
        //https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.tripledes?view=net-5.0

        static void Main(string[] args)
        {
            int passwordLength = 0;

            while (0 >= passwordLength || passwordLength > 20)
            {
                Console.WriteLine("Podaj długość hasła (do 20 znaków) i naciśnij Enter.");
                string passwordLengthStr = Console.ReadLine();
                int.TryParse(passwordLengthStr, out passwordLength);
            }

            Console.WriteLine($"Your password: {GeneratePassword(passwordLength)}");
        }

        public static string GeneratePassword (int passwordLength)
        {
            string strToEncrypt = String.Concat("BardzoDluuugi", DateTime.Now, "StringDoZaszyfrowania");
            byte[] toEncrypt = Encoding.ASCII.GetBytes(strToEncrypt);
            byte[] fromEncrypt = new byte[toEncrypt.Length];

            try
            {
                TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
            
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream
                        (memoryStream, tripleDES.CreateEncryptor(tripleDES.Key, tripleDES.IV), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);
                    }

                    fromEncrypt = memoryStream.ToArray();
                }
            }
            catch (Exception e)
            {
                return "Something went wrong";
            }
                                   
            const byte asciiRangeMin = 33;
            const byte asciiRangeMax = 126;

            for (int i = 0; i < passwordLength; i++)
            {
                while (fromEncrypt[i] > asciiRangeMax)
                {
                    fromEncrypt[i] -= asciiRangeMax;
                }

                if (fromEncrypt[i] < asciiRangeMin)
                {
                    fromEncrypt[i] += asciiRangeMin;
                }
            }

            string password = Encoding.ASCII.GetString(fromEncrypt).Substring(0, passwordLength);
            
            return password;
        }
    }
}
