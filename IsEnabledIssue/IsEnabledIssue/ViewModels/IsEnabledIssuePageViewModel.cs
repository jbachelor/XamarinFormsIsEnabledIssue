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

        private bool _allowWhitespaceCharacters;
        public bool AllowWhitespaceCharacters
        {
            get { return _allowWhitespaceCharacters; }
            set { SetProperty(ref _allowWhitespaceCharacters, value); }
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

            /*
            NOTE: If you have more than one property that your command needs to monitor to
            determine whether or not it can execute, you can chain together as many ObservesProperty
            statements as you need.
            
            If you skip using 'ObservesProperty', you need to add a call to MyButtonTappedCommand.RaiseCanExecuteChanged
            in the setters for EntryText and AllowWhitespaceCharacters.
             */
            MyButtonTappedCommand = new DelegateCommand(OnMyButtonTapped, CanExecuteOnMyButtonTapped)
                .ObservesProperty(() => EntryText)
                .ObservesProperty(() => AllowWhitespaceCharacters);
        }

        private bool CanExecuteOnMyButtonTapped()
        {
            var commandCanExecute = false;
            if (AllowWhitespaceCharacters == true)
            {
                commandCanExecute = EntryText?.Length > 4;
            }
            else
            {
                var entryWithoutWhitespace = EntryText?.Replace(" ", string.Empty);
                Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CanExecuteOnMyButtonTapped)}:  {nameof(entryWithoutWhitespace)}=[{entryWithoutWhitespace}]");
                commandCanExecute = entryWithoutWhitespace?.Length > 4;
            }
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(CanExecuteOnMyButtonTapped)}:  {commandCanExecute}");
            return commandCanExecute;
        }

        private void OnMyButtonTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnMyButtonTapped)}");
        }
    }
}
