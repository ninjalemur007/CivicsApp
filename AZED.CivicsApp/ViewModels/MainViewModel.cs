using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace AZED.CivicsApp.ViewModels
{
    public class MainViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            this.PageTitle = "Main";

            this.navigationService = navigationService;


        }


    }
}



//using System;
//using GalaSoft.MvvmLight;
//using GalaSoft.MvvmLight.Command;
//using GalaSoft.MvvmLight.Views;

//namespace AZED.CivicsApp.ViewModels
//{
//    public class MainViewModel : AppViewModelBase
//    {
//        private readonly INavigationService navigationService;

//        /// <summary>
//        /// Initializes a new instance of the MainViewModel class.
//        /// </summary>
//        public MainViewModel(INavigationService navigationService)
//        {
//            this.PageTitle = "Main";

//            this.navigationService = navigationService;

//            this.NavigateToStudyPageCommand = new RelayCommand(this.NavigateToStudyPage);
//            this.NavigateToQuizPageCommand = new RelayCommand(this.NavigateToQuizPage);
//            this.NavigateToTestPageCommand = new RelayCommand(this.NavigateToTestPage);
//        }

        
//        public RelayCommand NavigateToStudyPageCommand { get; private set; }

//        private void NavigateToStudyPage()
//        {
//            this.navigationService.NavigateTo(ConfigurationUtility.PageConstants.STUDY_PAGE);
//        }

//        public RelayCommand NavigateToTestPageCommand { get; private set; }

//        private void NavigateToTestPage()
//        {
//            this.navigationService.NavigateTo(ConfigurationUtility.PageConstants.TEST_PAGE);
//        }

//        public RelayCommand NavigateToQuizPageCommand { get; private set; }

//        private void NavigateToQuizPage()
//        {
//            this.navigationService.NavigateTo(ConfigurationUtility.PageConstants.QUIZ_PAGE);
//        }
//    }
//}