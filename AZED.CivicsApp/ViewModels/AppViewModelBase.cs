using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;

namespace AZED.CivicsApp.ViewModels
{
    public class AppViewModelBase : ViewModelBase
    {
        public AppViewModelBase()
        {
            this.AppTitle = "AZ Study";
        }

        private string _appTitle;
        public string AppTitle
        {
            get
            {
                return _appTitle;
            }
            set
            {
                if (Set(() => AppTitle, ref _appTitle, value))
                {
                    RaisePropertyChanged(() => AppTitle);
                }
            }
        }

        private string _pageTitle;
        public string PageTitle
        {
            get
            {
                return _pageTitle;
            }
            set
            {
                if (Set(() => PageTitle, ref _pageTitle, value))
                {
                    RaisePropertyChanged(() => PageTitle);
                }
            }
        }
    }
}
