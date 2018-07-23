using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIS.Mobile.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page";
            NavigateCommand = new DelegateCommand(ExecuteNavigateCommand);
        }

        async void ExecuteNavigateCommand()
        {
            await NavigationService.NavigateAsync("CoursePage");
        }
    }
}
