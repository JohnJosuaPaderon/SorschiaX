using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Sorschia
{
    public abstract class NavigableViewModelBase : ViewModelBase, INavigationAware
    {
        public NavigableViewModelBase(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator) : base(regionManager, dialogService, eventAggregator)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }
    }
}
