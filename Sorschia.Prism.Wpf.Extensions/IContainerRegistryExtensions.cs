using Prism.Ioc;
using Prism.Services.Dialogs;

namespace Sorschia
{
    public static class IContainerRegistryExtensions
    {
        public static IContainerRegistry AddDialog<TView>(this IContainerRegistry instance, string name = default)
        {
            instance.RegisterDialog<TView>(name);
            return instance;
        }

        public static IContainerRegistry AddNavigation<TView>(this IContainerRegistry instance, string name = default)
        {
            instance.RegisterForNavigation<TView>(name);
            return instance;
        }

        public static IContainerRegistry AddDialogWindow<TDialogWindow>(this IContainerRegistry instance)
            where TDialogWindow : IDialogWindow
        {
            instance.RegisterDialogWindow<TDialogWindow>();
            return instance;
        }
    }
}
