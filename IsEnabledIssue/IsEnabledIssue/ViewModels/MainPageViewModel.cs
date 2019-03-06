using IsEnabledIssue.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace IsEnabledIssue.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavToIssuePageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "IsEnabled Issue";
            NavToIssuePageCommand = new DelegateCommand(OnNavToIssuePageTapped);
        }

        private void OnNavToIssuePageTapped()
        {
            Debug.WriteLine($"**** {this.GetType().Name}.{nameof(OnNavToIssuePageTapped)}");
            _navigationService.NavigateAsync(nameof(IsEnabledIssuePage), null, false, true);
        }
    }
}
