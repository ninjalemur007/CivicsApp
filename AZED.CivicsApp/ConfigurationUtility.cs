using AZED.CivicsApp.Contracts;
using AZED.CivicsApp.Services;
using AZED.CivicsApp.ViewModels;
using AZED.CivicsApp.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp
{
    internal static class ConfigurationUtility
    {
        internal static class PageConstants
        {
            internal const string MAIN_PAGE = "MainPage";
            internal const string QUIZ_PAGE = "QuizPage";
            internal const string STUDY_PAGE = "StudyPage";
            internal const string STUDY1_PAGE = "StudySectionOnePage";
            internal const string STUDY2_PAGE = "StudySectionTwoPage";
            internal const string STUDY3_PAGE = "StudySectionThreePage";
            internal const string TEST_PAGE = "TestPage";
            internal const string S1INFO_PAGE = "SectionOneInfoPage";
            internal const string S2INFO_PAGE = "SectionTwoInfoPage";
            internal const string S3INFO_PAGE = "SectionThreeInfoPage";
            internal const string STUDYQA_PAGE = "StudyQAPage";

        }

        internal static NavigationService ConfigureNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure(PageConstants.MAIN_PAGE, typeof(MainPage));
            navigationService.Configure(PageConstants.QUIZ_PAGE, typeof(QuizPage));
            navigationService.Configure(PageConstants.STUDY_PAGE, typeof(StudyPage));
            navigationService.Configure(PageConstants.STUDY1_PAGE, typeof(StudySectionOnePage));
            navigationService.Configure(PageConstants.STUDY2_PAGE, typeof(StudySectionTwoPage));
            navigationService.Configure(PageConstants.STUDY3_PAGE, typeof(StudySectionThreePage));
            navigationService.Configure(PageConstants.TEST_PAGE, typeof(TestPage));
            navigationService.Configure(PageConstants.S1INFO_PAGE, typeof(SectionOneInfoPage));
            navigationService.Configure(PageConstants.S2INFO_PAGE, typeof(SectionTwoInfoPage));
            navigationService.Configure(PageConstants.S3INFO_PAGE, typeof(SectionThreeInfoPage));
            navigationService.Configure(PageConstants.STUDYQA_PAGE, typeof(StudyQAPage));


            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            return navigationService;
        }

        internal static void ConfigureViewModels()
        {
            // register all view models with IoC
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<QuizViewModel>();
            SimpleIoc.Default.Register<StudyViewModel>();
            SimpleIoc.Default.Register<StudySectionOneViewModel>();
            SimpleIoc.Default.Register<StudySectionTwoViewModel>();
            SimpleIoc.Default.Register<StudySectionThreeViewModel>();
            SimpleIoc.Default.Register<TestViewModel>();
            SimpleIoc.Default.Register<SectionOneInfoViewModel>();
            SimpleIoc.Default.Register<SectionTwoInfoViewModel>();
            SimpleIoc.Default.Register<SectionThreeInfoViewModel>();
            SimpleIoc.Default.Register<StudyQAViewModel>();
            SimpleIoc.Default.Register<ImageDetailViewModel>();

        }

        internal static void ConfigureServices()
        {
            //register all data services
            SimpleIoc.Default.Register<IQuestionAnswerDataService, QuestionAnswerDataService>();
            SimpleIoc.Default.Register<IStudyDataService, StudyDataService>();
            SimpleIoc.Default.Register<ISectionDataService, SectionDataService>();
            SimpleIoc.Default.Register<ISubsectionDataService, SubsectionDataService>();
        }
    }
}
