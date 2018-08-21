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
    public class SignupPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<College> Colleges { get; set; } = new ObservableRangeCollection<College>();
        public IPageDialogService _pageDialog { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        public SignupPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
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
            try
            {
                IsBusy = true;
                //Eto na yung GetStringAsync natin sa HttpClient
                var courses = await Client.GetTable<College>().ReadAsync();
                Colleges.ReplaceRange(courses);
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
        
        private Student student;

        public Student Student
        {
            get { return student; }
            set { SetProperty(ref student, value); }
        }

        private bool isEditing;
        public bool IsEditing
        {
            get { return isEditing; }
            set { SetProperty(ref isEditing, value); }
        }
        public ObservableRangeCollection<Student> Students { get; set; } = new ObservableRangeCollection<Student>();
        public DelegateCommand BtnSave { get; set; }
        public DelegateCommand BtnDelete { get; set; }

        public SignupPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Sign Up";
            BtnSave = new DelegateCommand(ExecuteBtnSave);
            BtnDelete = new DelegateCommand(ExecuteBtnDelete);
        }

        async void ExecuteBtnSave()
        {
            if (IsEditing)
            {
                await Client.GetTable<Student>().UpdateAsync(student);
            }
            else
            {
                Student.Id = Guid.NewGuid().ToString();
                await Client.GetTable<Student>().InsertAsync(Student);
            }
            await NavigationService.NavigateAsync("LoginPage");
        }

        async void ExecuteBtnDelete()
        {
            await Client.GetTable<Student>().DeleteAsync(Student);
            await NavigationService.GoBackAsync();
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("student"))
            {
                IsEditing = true;
                Student = (Student)parameters["student"];
            }
            else
            {
                Student = new Student();
            }
        }
    }
}


