using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;


namespace MIS.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand { get; set; }
        public DelegateCommand NavigateOrganization { get; set; }


        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand(ExecuteNavigateCommand);
            NavigateOrganization = new DelegateCommand(ExecuteNavigateOrganization);
           
        }

        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("CoursePage");
        }
        async void ExecuteNavigateOrganization()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/EventPage");
        }
        
    }
}
