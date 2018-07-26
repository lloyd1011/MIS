using MIS.Models;
using MvvmHelpers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MIS.Mobile.ViewModels
{
    public class SignupPageViewModel : ViewModelBase
    {
        private User user;

        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set { SetProperty(ref isEditing, value); }
        }
        public ObservableRangeCollection<User> Users { get; set; } = new ObservableRangeCollection<User>();
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public SignupPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sign Up";
            SaveCommand = new DelegateCommand(ExecuteSaveCommand);
            DeleteCommand = new DelegateCommand(ExecuteDeleteCommand);
        }

        async void ExecuteSaveCommand()
        {
            if (IsEditing)
            {
                await Client.GetTable<User>().UpdateAsync(user);
            }
            else
            {
                User.Id = Guid.NewGuid().ToString();
                await Client.GetTable<User>().InsertAsync(User);
            }
            await NavigationService.NavigateAsync("LoginPage");
        }

        async void ExecuteDeleteCommand()
        {
            await Client.GetTable<User>().DeleteAsync(User);
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("user"))
            {
                IsEditing = true;
                User = (User)parameters["user"];
            }
            else
            {
                User = new User();
            }
        }
    }
}


