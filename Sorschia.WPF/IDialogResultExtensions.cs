using Prism.Services.Dialogs;

namespace Sorschia
{
    public static class IDialogResultExtensions
    {
        public static IDialogResult AddParameter(this IDialogResult instance, string key, object value)
        {
            instance.Parameters.Add(key, value);
            return instance;
        }
    }
}
