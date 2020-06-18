using System.Text;

namespace Sorschia.Utilities
{
    internal sealed class FullNameBuilder : IFullNameBuilder
    {
        public string Build(string firstName, string middleName, string lastName, string nameExtension)
        {
            var builder = new StringBuilder();

            firstName = Sanitize(firstName);
            middleName = Sanitize(middleName);
            lastName = Sanitize(lastName);
            nameExtension = Sanitize(nameExtension);

            var hasFirstName = HasValue(firstName);
            var hasMiddleName = HasValue(middleName);
            var hasLastName = HasValue(lastName);
            var hasNameExtension = HasValue(nameExtension);

            if (hasLastName)
            {
                builder.Append(lastName);

                if (hasFirstName || hasNameExtension || hasMiddleName)
                {
                    builder.Append(", ");
                }
            }

            if (hasFirstName)
            {
                builder.Append(firstName);

                if (hasNameExtension || hasMiddleName)
                {
                    builder.Append(" ");
                }
            }

            if (hasNameExtension)
            {
                builder.Append(nameExtension);

                if (hasMiddleName)
                {
                    builder.Append(" ");
                }
            }

            if (hasMiddleName)
            {
                builder.Append(middleName);
            }

            return builder.ToString();
        }

        private string Sanitize(string value) => value?.Trim();

        private bool HasValue(string value) => !string.IsNullOrWhiteSpace(value);
    }
}
