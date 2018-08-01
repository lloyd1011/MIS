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
       public DelegateCommand NavMain { get; set; }
        public DelegateCommand NavSignup { get; set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
           NavSignup = new DelegateCommand(ExecuteNavigateCommand);
            NavMain = new DelegateCommand(ExecuteNavigate1Command);
        }
       
        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("SignupPage");
        }
        async void ExecuteNavigate1Command()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/MainPage");

        }   
    }
}

