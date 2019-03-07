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
            Title = "Using CanExecute";
            EntryHasAtLeastFiveCharacters = false;

            MyButtonTappedCommand = new DelegateCommand(OnMyButtonTapped);

            this.PropertyChanged += OnEntryTextChanged;
        }

        private void OnMyButtonTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnMyButtonTapped)}");
        }

        void OnEntryTextChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != nameof(EntryText))
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
