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
        public ObservableRangeCollection<User> Users { get; set; } = new ObservableRangeCollection<User>();
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<User> ItemSelectedCommand { get; set; }
        public IPageDialogService _pageDialog { get; set; }
        public SignupDetailPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            AddCommand = new DelegateCommand(ExecuteAddCommand);
            ItemSelectedCommand = new DelegateCommand<User>(ExecuteItemSelectedCommand);
            _pageDialog = pageDialog;
        }

        async void ExecuteItemSelectedCommand(User user)
        {
            var parameters = new NavigationParameters();
            parameters.Add("user", user);
            await NavigationService.NavigateAsync("LoginPage", parameters);
        }

        async void ExecuteAddCommand()
        {
            await NavigationService.NavigateAsync("LoginPage");
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
                var users = await Client.GetTable<User>().ReadAsync();
                Users.ReplaceRange(users);
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
