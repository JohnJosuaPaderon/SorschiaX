using System.Text;

namespace Sorschia
{
    internal abstract class NameBuilderBase
    {
        protected const string SPACE = " ";
        protected const string COMMA_SPACE = ", ";
        protected const string DOUBLE_SPACE = "  ";

        protected bool HasValue(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        protected string RemoveDoubleSeparators(string value)
        {
            var builder = new StringBuilder(value);

            while (value.Contains(DOUBLE_SPACE))
            {
                builder.Replace(DOUBLE_SPACE, SPACE);
            }

            return builder.ToString();
        }
    }
}
