using MIS.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
	public class CourseDetailPageViewModel : ViewModelBase
	{
        private Course course;

        public Course Course
        {
            get { return course; }
            set { SetProperty(ref course, value); }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set { SetProperty(ref isEditing, value); }
        }

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public CourseDetailPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Course Detail";
            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            DeleteCommand = new DelegateCommand(ExecuteDeleteCommand);
        }

        async void ExecuteSaveCommand()
        {
            if (IsEditing)
            {
                await Client.GetTable<Course>().UpdateAsync(course);
            }
            else
            {
                Course.Id = Guid.NewGuid().ToString();
                await Client.GetTable<Course>().InsertAsync(Course);
            }
            await NavigationService.GoBackAsync();
        }

        async void ExecuteDeleteCommand()
        {
            await Client.GetTable<Course>().DeleteAsync(Course);
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("course")) 
            {
                IsEditing = true;
                Course = (Course)parameters["course"];
            }
            else
            {
                Course = new Course();
            }
        }
    }
}
