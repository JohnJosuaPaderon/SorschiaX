using System.Text;

namespace Sorschia.Utilities
{
    internal sealed class FullNameBuilder : IFullNameBuilder
    {
        public string Build(string firstName, string middleName, string lastName, string nameSuffix)
        {
            var hasFirstName = !string.IsNullOrWhiteSpace(firstName);
            var hasMiddleName = !string.IsNullOrWhiteSpace(middleName);
            var hasLastName = !string.IsNullOrWhiteSpace(lastName);
            var hasNameSuffix = !string.IsNullOrWhiteSpace(nameSuffix);
            var builder = new StringBuilder();

            if (hasLastName)
            {
                builder.Append(lastName.Trim());

                if (hasFirstName || hasNameSuffix || hasMiddleName)
                    builder.Append(", ");
            }

            if (hasFirstName)
            {
                builder.Append(firstName.Trim());

                if (hasNameSuffix || hasMiddleName)
                    builder.Append(' ');
            }

            if (hasNameSuffix)
            {
                builder.Append(nameSuffix.Trim());

                if (hasMiddleName)
                    builder.Append(' ');
            }

            if (hasMiddleName)
                builder.Append(middleName.Trim());

            return builder.ToString();
        }
    }
}
