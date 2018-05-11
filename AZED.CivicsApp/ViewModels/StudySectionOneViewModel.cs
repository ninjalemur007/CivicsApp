using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class StudySectionOneViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public StudySectionOneViewModel(INavigationService navigationService)
        {
            this.PageTitle = "STUDY";

            this.navigationService = navigationService;
           
        }


    }
}
