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

        private bool _shouldEnableButtons;
        public bool ShouldEnableButtons
        {
            get { return _shouldEnableButtons; }
            set { SetProperty(ref _shouldEnableButtons, value); }
        }

        private string _entryText;
        public string EntryText
        {
            get { return _entryText; }
            set { SetProperty(ref _entryText, value); }
        }

        public IsEnabledIssuePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "IsEnabled Issue";
            ShouldEnableButtons = false;

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
                ShouldEnableButtons = true;
            }
            else
            {
                ShouldEnableButtons = false;
            }
        }
    }
}
