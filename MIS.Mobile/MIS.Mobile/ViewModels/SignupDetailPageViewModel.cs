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
	public class SignupDetailPageViewModel : ViewModelBase
	{
        public ObservableRangeCollection<Student> Students { get; set; } = new ObservableRangeCollection<Student>();
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<Student> ItemSelectedCommand { get; set; }
        public IPageDialogService _pageDialog { get; set; }
        public SignupDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            AddCommand = new DelegateCommand(ExecuteAddCommand);
            ItemSelectedCommand = new DelegateCommand<Student>(ExecuteItemSelectedCommand);
            _pageDialog = pageDialog;
        }

        async void ExecuteItemSelectedCommand(Student student)
        {
            var parameters = new NavigationParameters();
            parameters.Add("student", student);
            await NavigationService.NavigateAsync("SignupPage", parameters);
        }

        async void ExecuteAddCommand()
        {
            await NavigationService.NavigateAsync("SignupPage");
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
                var students = await Client.GetTable<Student>().ReadAsync();
                Students.ReplaceRange(students);
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
