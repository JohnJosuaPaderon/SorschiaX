using Sorschia.Security;
using System;
using System.Text;

namespace Sorschia.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var aesCrypto = new AesCrypto();
            var plainText = "johnjosua.paderon";
            var cryptoKeyString = "a";

            var cipherString = aesCrypto.Encrypt(plainText, cryptoKeyString);
            Console.WriteLine("Cipher: {0}", cipherString.GetCipherText());
            Console.WriteLine("IV: {0}", cipherString.GetIvText());
            Console.WriteLine("Salt: {0}", cipherString.GetSaltText());
            Console.WriteLine(aesCrypto.Decrypt(cipherString.GetCipherText(), cryptoKeyString));
            Console.ReadKey();
        }
    }
}
