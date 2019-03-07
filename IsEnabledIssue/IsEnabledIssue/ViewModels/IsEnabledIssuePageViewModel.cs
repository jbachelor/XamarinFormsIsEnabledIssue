using System;
using System.ComponentModel;
using System.Diagnostics;
using Prism.Commands;
using Prism.Navigation;

namespace IsEnabledIssue.ViewModels
{
    public class IsEnabledIssuePageViewModel : ViewModelBase
    {
        public DelegateCommand MyButtonTappedCommand { get; set; }

        private bool _entryHasAtLeastFiveCharacters;
        public bool EntryHasAtLeastFiveCharacters
        {
            get { return _entryHasAtLeastFiveCharacters; }
            set { SetProperty(ref _entryHasAtLeastFiveCharacters, value); }
        }

        private string _entryText;
        public string EntryText
        {
            get { return _entryText; }
            set { SetProperty(ref _entryText, value); }
        }

        private string _explanationText;
        public string ExplanationText
        {
            get { return _explanationText; }
            set { SetProperty(ref _explanationText, value); }
        }

        public IsEnabledIssuePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Using ObservesProperty";
            EntryHasAtLeastFiveCharacters = false;

            // NOTE: If you have more than one property that your command needs to monitor to
            // determine whether or not it can execute, you can chain together as many ObservesProperty
            // statements as you need.
            MyButtonTappedCommand = new DelegateCommand(OnMyButtonTapped, CanExecuteCommand)
                .ObservesProperty(() => EntryHasAtLeastFiveCharacters);

            this.PropertyChanged += OnEntryTextChanged;
        }

        private bool CanExecuteCommand()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CanExecuteCommand)}:  {EntryHasAtLeastFiveCharacters}");
            return EntryHasAtLeastFiveCharacters;
        }

        private void OnMyButtonTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnMyButtonTapped)}");
        }

        void OnEntryTextChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(EntryText))
            {
                return;
            }

            if (EntryText.Length > 4)
            {
                EntryHasAtLeastFiveCharacters = true;
            }
            else
            {
                EntryHasAtLeastFiveCharacters = false;
            }
        }
    }
}
