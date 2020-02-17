using System.Text;

namespace Sorschia
{
    internal sealed class InformalFullNameBuilder : NameBuilderBase, IInformalFullNameBuilder
    {
        public string Build(NameBase name)
        {
            if (name == null)
            {
                throw new SorschiaException($"Parameter '{nameof(name)}' cannot be null");
            }

            return Build(name.FirstName, name.MiddleInitials, name.LastName, name.NameExtension);
        }

        public string Build(string firstName, string middleInitials, string lastName, string nameExtension)
        {
            var builder = new StringBuilder();

            var hasFirstName = HasValue(firstName);
            var hasMiddleInitials = HasValue(middleInitials);
            var hasLastName = HasValue(lastName);
            var hasNameExtension = HasValue(nameExtension);

            if (hasFirstName)
            {
                builder.Append(firstName.Trim());

                if (hasMiddleInitials || hasLastName || hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }

            if (hasMiddleInitials)
            {
                builder.Append($"{middleInitials}.");

                if (hasLastName || hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }

            if (hasLastName)
            {
                builder.Append(lastName.Trim());

                if (hasNameExtension)
                {
                    builder.Append(SPACE);
                }
            }

            if (hasNameExtension)
            {
                builder.Append(nameExtension);
            }

            return builder.ToString();
        }
    }
}
