using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class EventPageViewModel : ViewModelBase
    {
        public EventPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Events";
        }
    }
}
