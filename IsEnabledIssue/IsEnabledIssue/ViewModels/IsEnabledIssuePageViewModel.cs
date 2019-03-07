using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Prism.Logging;
using Prism.Services;
using System.Diagnostics;
using System.ComponentModel;

namespace IsEnabledIssue.ViewModels
{
    public class IsEnabledIssuePageViewModel : ViewModelBase
    {
        public DelegateCommand IsEnabledAboveTappedCommand { get; set; }
        public DelegateCommand IsEnabledBelowTappedCommand { get; set; }

        int _numberOfTimesButtonsHaveBeenEnabled = 0;

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
            Title = "IsEnabled Issue";
            EntryHasAtLeastFiveCharacters = false;
            SetExplanationText();

            IsEnabledAboveTappedCommand = new DelegateCommand(OnIsEnabledAboveTapped);
            IsEnabledBelowTappedCommand = new DelegateCommand(OnIsEnabledBelowTapped);

            this.PropertyChanged += OnEntryTextChanged;
        }

        private void OnIsEnabledAboveTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnIsEnabledAboveTapped)}");
        }

        private void OnIsEnabledBelowTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnIsEnabledBelowTapped)}");
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
                _numberOfTimesButtonsHaveBeenEnabled++;
                if(_numberOfTimesButtonsHaveBeenEnabled == 1)
                {
                    ExplanationText += $"\n\nInterestingly enough, once {nameof(EntryHasAtLeastFiveCharacters)} changes from false to true, the top button starts working properly.\n\nTo see the issue again, you must navigate back, then return to this page. This page will get destroyed when you navigate back, effectively resetting the experiment for another run.";
                }
            }
            else
            {
                EntryHasAtLeastFiveCharacters = false;
            }
        }

        private void SetExplanationText()
        {
            ExplanationText=$"Both of the buttons above have their IsEnabled property wired up to the same {nameof(EntryHasAtLeastFiveCharacters)} property in the ViewModel, but only the bottom button behaves as expected.";
        }
    }
}
