using Sorschia.Security;
using System;
using System.Text;

namespace Sorschia.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorschia.Security.AesCrypto

            //var aesCrypto = new AesCrypto();
            //var plainText = "johnjosua.paderon";
            //var cryptoKeyString = "a";

            //var cipherString = aesCrypto.Encrypt(plainText, cryptoKeyString);
            //Console.WriteLine("Cipher: {0}", cipherString.GetCipherText());
            //Console.WriteLine("IV: {0}", cipherString.GetIvText());
            //Console.WriteLine("Salt: {0}", cipherString.GetSaltText());
            //Console.WriteLine(aesCrypto.Decrypt(cipherString.GetCipherText(), cryptoKeyString));

            //Sorschia.Security.RsaCrypto

            var rsaCrypto = new RsaCrypto();
            var publicKeyStore = new RsaPublicKeyStore();
            var privateKeyStore = new RsaPrivateKeyStore(publicKeyStore);
            var rsaKeys1 = privateKeyStore.Initialize("user-username");
            var rsaKeys2 = privateKeyStore.Initialize("user-password");

            var publicKeyPemString = RsaKeyConverter.ToPublicKeyPemString(rsaKeys1.PublicKey);
            var privateKeyPemString = RsaKeyConverter.ToPrivateKeyPemString(rsaKeys1.PrivateKey);
            Console.WriteLine(RsaKeyConverter.ToPublicKeyPemString(rsaKeys1.PublicKey));
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(RsaKeyConverter.ToPrivateKeyPemString(rsaKeys1.PrivateKey));
            var cipherData = rsaCrypto.Encrypt(Encoding.UTF8.GetBytes("johnjosua.paderon"), publicKeyStore.Request("user-username"));
            var cipherText = Convert.ToBase64String(cipherData);

            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine(cipherText);
            Console.WriteLine(); Console.WriteLine();
            var data = rsaCrypto.Decrypt(Convert.FromBase64String(cipherText), privateKeyStore.Request("user-username"));
            var text = Encoding.UTF8.GetString(data);
            Console.WriteLine(text);

            Console.ReadKey();
        }
    }
}
