using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MIS.Mobile.ViewModels
{
    public class AttendancePageViewModel : ViewModelBase
    {
        public DelegateCommand OpenScannerCommand { get; set; }
        public IPageDialogService _dialogService;
        public AttendancePageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            Icon = "Attendance.png";
            Title = "Attendance";
            _dialogService = dialogService;
            OpenScannerCommand = new DelegateCommand(ExecuteOpenScannerCommand);
        }
        public async void ExecuteOpenScannerCommand()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (status != PermissionStatus.Granted)
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
            else
                await NavigationService.NavigateAsync("AttendanceScannerPage");
        }

        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("ScannedItem"))
            {
                var itemResult = (string)parameters["ScannedItem"];
                await _dialogService.DisplayAlertAsync("Result", $"You have scanned {itemResult}", "Close");
                
            }
        }

    }
}
