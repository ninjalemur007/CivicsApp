using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AZED.CivicsApp.ViewModels
{
    public class TestViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public TestViewModel(INavigationService navigationService)
        {
            this.PageTitle = "TEST";

            this.navigationService = navigationService;
        }

    }

}
