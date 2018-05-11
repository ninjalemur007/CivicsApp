using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class SectionOneInfoViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public SectionOneInfoViewModel(INavigationService navigationService)
        {
            this.PageTitle = "INFORMATION";

            this.navigationService = navigationService;

        }

    }
}
