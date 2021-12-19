using MonAnNgon.Models;
using MonAnNgon.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MonAnNgon.ViewModels
{
    public class BaseViewModel : MVVM.BindableBase
    {
        private bool _isBusy;
        private string _title;

        public AppDataStore DataStore => DependencyService.Get<AppDataStore>();

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (SetProperty(ref _isBusy, value))
                {
                    RaisePropertyChanged(nameof(IsNotBusy));
                }
            }
        }

        public bool IsNotBusy => !IsBusy;

        public Database Db { get; }

        public BaseViewModel()
        {
            Db = new Database();
        }
    }
}
