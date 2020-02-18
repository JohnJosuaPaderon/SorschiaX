using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;

namespace Sorschia
{
    public abstract class DialogViewModelBase : ViewModelBase, IDialogAware
    {
        public DialogViewModelBase(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator) : base(regionManager, dialogService, eventAggregator)
        {
        }

        public event Action<IDialogResult> RequestClose;

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        protected virtual void OnRequestClosed(IDialogResult result)
        {
            RequestClose?.Invoke(result);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public virtual void OnDialogClosed()
        {
        }
    }
}
