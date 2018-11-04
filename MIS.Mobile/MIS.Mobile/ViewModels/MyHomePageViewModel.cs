using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class MyHomePageViewModel : ViewModelBase
    {

        public DelegateCommand NavigateOrganization { get; set; }
        public DelegateCommand NavigateNotification { get; set; }
        public DelegateCommand NavigateLogout { get; set; }

        public MyHomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            NavigateOrganization = new DelegateCommand(ExecuteNavigateOrganization);
            NavigateNotification = new DelegateCommand(ExecuteNavigateNotification);
            NavigateLogout = new DelegateCommand(ExecuteNavigateLogout);
        }

        async void ExecuteNavigateOrganization()
        {
            await NavigationService.NavigateAsync("MyHomePage/NavigationPage/MainPage");
        }
        async void ExecuteNavigateNotification()
        {
            await NavigationService.NavigateAsync("MyHomePage/NavigationPage/NotificationPage");
        }
        async void ExecuteNavigateLogout()
        {
            await NavigationService.NavigateAsync("MyHomePage/NavigationPage/LoginPage");
        }
    }
}
