using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class CoursePageViewModel : ViewModelBase
    {
        ObservableRangeCollection<Course> Courses = new ObservableRangeCollection<Course>();
        public CoursePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }
    }
}
