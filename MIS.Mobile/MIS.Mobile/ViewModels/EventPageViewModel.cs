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
    public class EventPageViewModel : ViewModelBase
    {
        public ObservableRangeCollection<Event> Events { get; set; } = new ObservableRangeCollection<Event>();
        public DelegateCommand RefreshCommand { get; set; }
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand<Event> ItemSelectedCommand { get; set; }
        public IPageDialogService _pageDialog { get; set; }
        public EventPageViewModel(INavigationService navigationService, IPageDialogService pageDialog) : base(navigationService)
        {
            Title = "Events";
            RefreshCommand = new DelegateCommand(ExecuteRefreshCommand);
            AddCommand = new DelegateCommand(ExecuteAddCommand);
            ItemSelectedCommand = new DelegateCommand<Event>(ExecuteItemSelectedCommand);
            _pageDialog = pageDialog;
        }

        async void ExecuteItemSelectedCommand(Event events)
        {
            var parameters = new NavigationParameters();
            parameters.Add("event", events);
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
                var events = await Client.GetTable<Event>().ReadAsync();
                Events.ReplaceRange(events);
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
