using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.OpenSsl;
using System.IO;

namespace Sorschia.Security
{
    internal sealed class PemStringConverter
    {
        public string FromCryptoKey(AsymmetricKeyParameter key)
        {
            if (key is null)
                throw new SorschiaSecurityException("key is null");

            using var stringWriter = new StringWriter();
            var pemWriter = new PemWriter(stringWriter);
            pemWriter.WriteObject(key);
            pemWriter.Writer.Flush();
            return stringWriter.ToString();
        }

        public AsymmetricKeyParameter ToPublicKey(string pemString)
        {
            if (string.IsNullOrWhiteSpace(pemString))
                throw new SorschiaSecurityException("Pemstring is null or white-space");

            using var stringReader = new StringReader(pemString);
            var pemReader = new PemReader(stringReader);
            return pemReader.ReadObject() as AsymmetricKeyParameter;
        }

        public AsymmetricKeyParameter ToPrivateKey(string pemString)
        {
            if (string.IsNullOrWhiteSpace(pemString))
                throw new SorschiaSecurityException("Pemstring is null or white-space");

            using var stringReader = new StringReader(pemString);
            var pemReader = new PemReader(stringReader);
            var keyPair = (AsymmetricCipherKeyPair)pemReader.ReadObject();

            if (keyPair is null)
                throw new SorschiaSecurityException("Keypair is null");

            return keyPair.Private;
        }
    }
}
