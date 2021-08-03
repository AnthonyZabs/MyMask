using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMask.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private INavigationService _navigationService;

        private int accountNumber;

        public int AccountNumber
        {
            get { return accountNumber; }
            set { SetProperty(ref accountNumber, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public void OnNavigatedTo(INavigationParameters parameters) { }

        public void OnNavigatingTo(INavigationParameters parameters) { }
    }
}
