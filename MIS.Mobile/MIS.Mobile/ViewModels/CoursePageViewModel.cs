using MIS.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MIS.Mobile.ViewModels
{
	public class CoursePageViewModel : ViewModelBase
	{
        public ObservableRangeCollection<Course> Courses { get; set; } = new ObservableRangeCollection<Course>();
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<Course> ItemSelectedCommand { get; set; }
        public IPageDialogService _pageDialog { get; set; }
        public CoursePageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            Title = "Courses";
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            AddCommand = new DelegateCommand(ExecuteAddCommand);
            ItemSelectedCommand = new DelegateCommand<Course>(ExecuteItemSelectedCommand);
            _pageDialog = pageDialog;
        }

        async void ExecuteItemSelectedCommand(Course course)
        {
            var parameters = new NavigationParameters();
            parameters.Add("course", course);
            await NavigationService.NavigateAsync("CourseDetailPage", parameters);
        }

        async void ExecuteAddCommand()
        {
            await NavigationService.NavigateAsync("CourseDetailPage");
        }

        async void ExecuteRefreshCommand()
        {
            await LoadItemsAsync();
        }

        async Task LoadItemsAsync()
        {
            try
            {
                IsBusy = true;
                //Eto na yung GetStringAsync natin sa HttpClient
                var courses = await Client.GetTable<Course>().ReadAsync();
                Courses.ReplaceRange(courses);
            }
            catch (Exception ex)
            {
                await _pageDialog.DisplayAlertAsync("Error", ex.Message, "Ok");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            RefreshCommand.Execute();
        }
    }
}
