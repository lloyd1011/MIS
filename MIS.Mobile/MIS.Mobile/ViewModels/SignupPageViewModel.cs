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


