using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class SectionThreeInfoViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public SectionThreeInfoViewModel(INavigationService navigationService)
        {
            this.PageTitle = "INFORMATION";

            this.navigationService = navigationService;

        }

    }
}
