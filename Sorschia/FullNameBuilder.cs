using System.Text;

namespace Sorschia
{
    internal sealed class FullNameBuilder : NameBuilderBase, IFullNameBuilder
    {
        public string Build(NameBase name)
        {
            if (name == null)
            {
                throw new SorschiaException($"Parameter '{nameof(name)}' cannot be null");
            }

            return Build(name.FirstName, name.MiddleName, name.LastName, name.NameExtension);
        }

        public string Build(string firstName, string middleName, string lastName, string nameExtension)
        {
            var builder = new StringBuilder();

            var hasFirstName = HasValue(firstName);
            var hasMiddleName = HasValue(middleName);
            var hasLastName = HasValue(lastName);
            var hasNameExtension = HasValue(nameExtension);

            if (hasLastName)
            {
                builder.Append(lastName.Trim());

                if (hasNameExtension)
                {
                    builder.Append(SPACE);
                }
                else if (hasFirstName || hasMiddleName)
                {
                    builder.Append(COMMA_SPACE);
                }
            }

            if (hasNameExtension)
            {
                builder.Append(nameExtension.Trim());

                if (hasFirstName || hasMiddleName)
                {
                    builder.Append(COMMA_SPACE);
                }
            }

            if (hasFirstName)
            {
                builder.Append(firstName.Trim());

                if (hasMiddleName)
                {
                    builder.Append(SPACE);
                }
            }

            if (hasMiddleName)
            {
                builder.Append(middleName.Trim());
            }

            return builder.ToString();
        }
    }
}
