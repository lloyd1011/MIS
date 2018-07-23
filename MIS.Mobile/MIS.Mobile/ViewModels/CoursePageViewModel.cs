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
        public IPageDialogService _pageDialog { get; set; }
        public CoursePageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            _pageDialog = pageDialog;
        }

        async void ExecuteRefreshCommand()
        {
            await LoadItemsAsync();
        }

        async Task LoadItemsAsync()
        {
            IsBusy = true;
            try
            {
                //Eto na yung GetStringAsync natin sa HttpClient
                var courses = await Client.GetTable<Course>().ReadAsync();
                Courses.ReplaceRange(courses);
            }
            catch (Exception ex)
            {
                await _pageDialog.DisplayAlertAsync("Error", ex.Message, "Ok");
            }
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            RefreshCommand.Execute();
        }
    }
}
