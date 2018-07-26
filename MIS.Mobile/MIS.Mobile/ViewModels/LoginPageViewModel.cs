using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
       public DelegateCommand Nav { get; set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
           Nav = new DelegateCommand(ExecuteNavigateCommand);
        }
       
        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("SignupPage");
        }
    }
}

