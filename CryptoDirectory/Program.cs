using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CryptoDirectory
{
    class Program
    {
        private static string _filePath = "/Users/aidenwilde/Documents/Development/CryptoDirectory/CryptoDirectory/test.txt";
        
        static void Main(string[] args)
        {
            var encoding = new UTF8Encoding();
            var filedata = File.ReadAllText(_filePath);            
            using (AesCryptoServiceProvider myAes = new AesCryptoServiceProvider())
            {
                byte[] encrypted = AesFileCrypto.Encrypt(filedata, myAes.Key, myAes.IV);
                string decrypted = AesFileCrypto.Decrypt(encrypted, myAes.Key, myAes.IV);

                Console.WriteLine("encrypted: {0}", encoding.GetString(encrypted));
                Console.WriteLine("decrypted: {0}", decrypted);
            }
        }
    }
}