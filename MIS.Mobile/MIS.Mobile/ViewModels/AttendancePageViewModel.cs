using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class AttendancePageViewModel : ViewModelBase
    {
        public AttendancePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Icon = "Attendance.png";
            Title = "Attendance";
        }
    }
}
