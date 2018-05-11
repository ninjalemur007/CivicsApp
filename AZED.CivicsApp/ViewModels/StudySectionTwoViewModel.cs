using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class StudySectionTwoViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public StudySectionTwoViewModel(INavigationService navigationService)
        {
            this.PageTitle = "STUDY";

            this.navigationService = navigationService;

        }

    }
}
