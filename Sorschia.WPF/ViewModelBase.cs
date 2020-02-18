using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace Sorschia
{
    public abstract partial class ViewModelBase : BindableBase
    {
        public ViewModelBase(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            DialogService = dialogService;
            EventAggregator = eventAggregator;
        }

        protected IRegionManager RegionManager { get; }
        protected IDialogService DialogService { get; }
        protected IEventAggregator EventAggregator { get; }

        protected void Invoke(Action callback)
        {
            Application.Current.Dispatcher.Invoke(callback);
        }
    }
}
