﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace MIS.Mobile.ViewModels
{
    public class AttendanceScannerPageViewModel : ViewModelBase
    { 
           #region Properties
    public ZXing.Result Result { get; set; }
    private bool isAnalyzing = true;
    public bool IsAnalyzing
    {
        get { return isAnalyzing; }
        set
        {
            SetProperty(ref isAnalyzing, value, "IsAnalyzing");
        }
    }

    private bool isScanning = true;
    public bool IsScanning
    {
        get { return isScanning; }
        set
        {
            SetProperty(ref isScanning, value, "IsScanning");
        }
    }

    public DelegateCommand ScanCommand { get; }
        #endregion

        public AttendanceScannerPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Scan To Attend";
            ScanCommand = new DelegateCommand(ExecuteScanCommand);
        }

    void ExecuteScanCommand()
    {
        IsAnalyzing = false;
        IsScanning = false;
        Device.BeginInvokeOnMainThread(async () =>
        {
            var p = new NavigationParameters
                {
                    {
                        "ScannedItem", Result.Text
                    }
                };
            await NavigationService.GoBackAsync(p);
        });
    }
}
}

