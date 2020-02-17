using System;
using System.Text;

namespace Sorschia
{
    internal sealed class MiddleInitialsBuilder : NameBuilderBase, IMiddleInitialsBuilder
    {
        public string Build(NameBase name)
        {
            if (name == null)
            {
                throw new SorschiaException($"Parameter '{nameof(name)}' cannot be null");
            }

            return Build(name.MiddleName);
        }

        public string Build(string middleName)
        {
            var builder = new StringBuilder();

            var cleansed = RemoveDoubleSeparators(middleName);
            var chunks = cleansed.Split(new string[] { SPACE }, StringSplitOptions.RemoveEmptyEntries);

            if (chunks.Length > 0)
            {
                foreach (var chunk in chunks)
                {
                    var firstCharacter = chunk[0];

                    if (char.IsLetter(firstCharacter))
                    {
                        builder.Append(firstCharacter);
                    }
                }
            }

            return builder.ToString();
        }
    }
}
