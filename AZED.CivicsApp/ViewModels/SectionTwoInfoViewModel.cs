using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class SectionTwoInfoViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public SectionTwoInfoViewModel(INavigationService navigationService)
        {
            this.PageTitle = "INFORMATION";

            this.navigationService = navigationService;

        }

    }
}
