using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using System;

namespace Sorschia.Security
{
    internal sealed class RsaCryptoKeyGenerator : IRsaCryptoKeyGenerator
    {
        private readonly PemStringConverter _converter;

        public RsaCryptoKeyGenerator(PemStringConverter converter)
        {
            _converter = converter;
        }

        public RsaCryptoKeyPair Generate()
        {
            var rsaKeyParams = new RsaKeyGenerationParameters(BigInteger.ProbablePrime(512, new Random()), new SecureRandom(), 1024, 25);
            var keyGenerator = new RsaKeyPairGenerator();
            keyGenerator.Init(rsaKeyParams);
            var pair = keyGenerator.GenerateKeyPair();

            return new RsaCryptoKeyPair(_converter.FromCryptoKey(pair.Private), _converter.FromCryptoKey(pair.Public));
        }
    }
}
