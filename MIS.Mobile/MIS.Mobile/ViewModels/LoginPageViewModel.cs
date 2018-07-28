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
        public DelegateCommand Nav1 { get; set; }
        public LoginPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            
           Nav = new DelegateCommand(ExecuteNavigateCommand);
            Nav1 = new DelegateCommand(ExecuteNavigate1Command);
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

