using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class AltChooseQuizSectionViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

		public AltChooseQuizSectionViewModel(INavigationService navigationService)
        {

            this.navigationService = navigationService;
           
        }


    }
}
