using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Events;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace Sorschia.ViewModels
{
    public sealed class MessageDisplayViewModel : DialogViewModelBase
    {
        public MessageDisplayViewModel(IRegionManager regionManager, IDialogService dialogService, IEventAggregator eventAggregator) : base(regionManager, dialogService, eventAggregator)
        {
            InvokeButtonClickCommand = new DelegateCommand<string>(InvokeButtonClick);
        }

        public DelegateCommand<string> InvokeButtonClickCommand { get; }

        private string _headerText;
        public string HeaderText
        {
            get { return _headerText; }
            set { SetProperty(ref _headerText, value); }
        }

        private string _content;
        public string Content
        {
            get { return _content; }
            set { SetProperty(ref _content, value); }
        }

        private MessageBoxButton _button;
        public MessageBoxButton Button
        {
            get { return _button; }
            set { SetProperty(ref _button, value); }
        }

        private PackIconKind _iconKind;
        public PackIconKind IconKind
        {
            get { return _iconKind; }
            set { SetProperty(ref _iconKind, value); }
        }

        private Visibility _okButtonVisibility;
        public Visibility OkButtonVisibility
        {
            get { return _okButtonVisibility; }
            set { SetProperty(ref _okButtonVisibility, value); }
        }

        private Visibility _cancelButtonVisibility;
        public Visibility CancelButtonVisibility
        {
            get { return _cancelButtonVisibility; }
            set { SetProperty(ref _cancelButtonVisibility, value); }
        }

        private Visibility _yesButtonVisibility;
        public Visibility YesButtonVisibility
        {
            get { return _yesButtonVisibility; }
            set { SetProperty(ref _yesButtonVisibility, value); }
        }

        private Visibility _noButtonVisibility;
        public Visibility NoButtonVisibility
        {
            get { return _noButtonVisibility; }
            set { SetProperty(ref _noButtonVisibility, value); }
        }

        private bool _okButtonFocused;
        public bool OkButtonFocused
        {
            get { return _okButtonFocused; }
            set { SetProperty(ref _okButtonFocused, value); }
        }

        private bool _cancelButtonFocused;
        public bool CancelButtonFocused
        {
            get { return _cancelButtonFocused; }
            set { SetProperty(ref _cancelButtonFocused, value); }
        }

        private bool _yesButtonFocused;
        public bool YesButtonFocused
        {
            get { return _yesButtonFocused; }
            set { SetProperty(ref _yesButtonFocused, value); }
        }

        private bool _noButtonFocused;
        public bool NoButtonFocused
        {
            get { return _noButtonFocused; }
            set { SetProperty(ref _noButtonFocused, value); }
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            OkButtonVisibility = Visibility.Collapsed;
            CancelButtonVisibility = Visibility.Collapsed;
            YesButtonVisibility = Visibility.Collapsed;
            NoButtonVisibility = Visibility.Collapsed;
            OkButtonFocused = false;
            CancelButtonFocused = false;
            YesButtonFocused = false;
            NoButtonFocused = false;

            if (parameters.TryGetValue(DialogConstants.MessageDisplay_Model, out MessageDisplayModel model))
            {
                HeaderText = model.HeaderText;
                Content = model.Content;
                Button = model.Button;

                switch (model.Image)
                {
                    case MessageBoxImage.None:
                        IconKind = PackIconKind.About;
                        break;
                    case MessageBoxImage.Question:
                        IconKind = PackIconKind.QuestionMark;
                        break;
                    case MessageBoxImage.Error:
                        IconKind = PackIconKind.Error;
                        break;
                    case MessageBoxImage.Warning:
                        IconKind = PackIconKind.Warning;
                        break;
                    case MessageBoxImage.Information:
                        IconKind = PackIconKind.About;
                        break;
                    default:
                        IconKind = PackIconKind.About;
                        break;
                }

                switch (model.Button)
                {
                    case MessageBoxButton.OK:
                        OkButtonVisibility = Visibility.Visible;
                        OkButtonFocused = true;
                        break;
                    case MessageBoxButton.OKCancel:
                        OkButtonVisibility = Visibility.Visible;
                        CancelButtonVisibility = Visibility.Visible;
                        OkButtonFocused = true;
                        break;
                    case MessageBoxButton.YesNoCancel:
                        YesButtonVisibility = Visibility.Visible;
                        NoButtonVisibility = Visibility.Visible;
                        CancelButtonVisibility = Visibility.Visible;
                        YesButtonFocused = true;
                        break;
                    case MessageBoxButton.YesNo:
                        YesButtonVisibility = Visibility.Visible;
                        NoButtonVisibility = Visibility.Visible;
                        YesButtonFocused = true;
                        break;
                }
            }
        }

        private void InvokeButtonClick(string resultString)
        {
            if (Enum.TryParse(resultString, out ButtonResult result))
            {
                OnRequestClosed(new DialogResult(result));
            }
        }
    }
}
