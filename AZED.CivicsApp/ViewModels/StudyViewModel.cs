using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace AZED.CivicsApp.ViewModels
{
    public class StudyViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public StudyViewModel(INavigationService navigationService)
        {
            this.PageTitle = "STUDY";

            this.navigationService = navigationService;

        }


    }

}
