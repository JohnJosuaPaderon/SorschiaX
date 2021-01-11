using System;
using System.Text;

namespace Sorschia.Security
{
    public static class ICryptoHashExtensions
    {
        public static string? Compute(this ICryptoHash instance, string? text, Encoding encoding)
        {
            if (text is null || text.Length == 0)
                return null;

            var hash = instance.Compute(encoding.GetBytes(text));
            
            if (hash is not null)
                return new StringBuilder(BitConverter.ToString(hash))
                .Replace("-", string.Empty)
                .ToString();

            return null;
        }

        public static string? Compute(this ICryptoHash instance, string? text) => instance.Compute(text, Encoding.UTF8);
    }
}
