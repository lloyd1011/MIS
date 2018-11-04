using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
	public class PrismMasterDetailPage1ViewModel :ViewModelBase
	{
        public DelegateCommand NavigateHome { get; set; }
        public DelegateCommand NavigateProfile { get; set; }
        public DelegateCommand NavigateEvent { get; set; }
        public DelegateCommand NavigateEvaluation { get; set; }
        public DelegateCommand NavigateLiabilities { get; set; }
        public DelegateCommand NavigateAttendance { get; set; }
       

        public PrismMasterDetailPage1ViewModel(INavigationService navigationService) : base(navigationService)
        {
            
            NavigateProfile = new DelegateCommand(ExecuteNavigateProfile);
            NavigateEvent = new DelegateCommand(ExecuteNavigateEvent);
            NavigateEvaluation = new DelegateCommand(ExecuteNavigateEvaluation);
            NavigateHome = new DelegateCommand(ExecuteNavigateHome);
            NavigateLiabilities = new DelegateCommand(ExecuteNavigateLiabilities);
            NavigateAttendance = new DelegateCommand(ExecuteNavigateAttendance);
        }

        async void ExecuteNavigateProfile()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/MyProfilePage");
        }
        async void ExecuteNavigateEvent()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/EventPage");
        }
        async void ExecuteNavigateEvaluation()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/EvaluationPage");
        }
        async void ExecuteNavigateHome()
        {
            await NavigationService.NavigateAsync("MyHomePage/NavigationPage/MainPage");
        }
        async void ExecuteNavigateLiabilities()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/LiabilitiesPage");
        }
        async void ExecuteNavigateAttendance()
        {
            await NavigationService.NavigateAsync("PrismMasterDetailPage1/NavigationPage/AttendancePage");
        }

    }
}
