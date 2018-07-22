using MIS.Mobile.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace MIS.Mobile.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        private HttpClient client;

        public HttpClient Client
        {
            get {
                if (client == null)
                {
                    client = new HttpClient();
                    client.BaseAddress = new url("http://mobilepedia.azurewebsites.com");
                    return client;
                }
                return client;
            }
        }

        private MISDBContext database;

        public MISDBContext Database
        {
            get
            {
                if (database == null)
                {
                    database = new MISDBContext();
                    return database;
                }
                return database;
            }
        }

        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
