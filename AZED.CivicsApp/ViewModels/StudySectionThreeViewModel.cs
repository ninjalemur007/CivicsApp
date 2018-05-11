using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class StudySectionThreeViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public StudySectionThreeViewModel(INavigationService navigationService)
        {
            this.PageTitle = "STUDY";

            this.navigationService = navigationService;

        }

    }
}
