using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Sorschia.Entities;
using Sorschia.Security;

namespace Sorschia.Generators
{
    public sealed class UserPasswordHashGenerator : ValueGenerator<string>
    {
        public override bool GeneratesTemporaryValues => false;

        public override string Next(EntityEntry entry)
        {
            if (entry.Entity is User user)
            {
                var cryptoHash = entry.Context.GetService<IGlobalCryptoHash>();
                var decryptor = entry.Context.GetService<IGlobalDecryptor>();

                if (user.Password is not null && user.Password.Length > 0)
                    return cryptoHash.Compute(user.Password);
                else if (user.CipherPassword is not null && user.CipherPassword.Length > 0)
                    return cryptoHash.Compute(decryptor.Decrypt(user.CipherPassword));
            }

            return null;
        }
    }
}
