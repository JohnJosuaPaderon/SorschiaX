using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Sorschia.ViewModels
{
    public sealed class NotFoundViewModel : NavigableViewModelBase
    {
        public NotFoundViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator) : base(regionManager, dialogService, eventAggregator)
        {
        }

        private string _targetView;
        public string TargetView
        {
            get { return _targetView; }
            set { SetProperty(ref _targetView, value); }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            TargetView = navigationContext.Parameters.TryGetValue(NavigationConstants.NotFound_TargetView, out string targetView) ? targetView : "[source-not-found]";
        }
    }
}
