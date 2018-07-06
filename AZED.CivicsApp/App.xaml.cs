using AZED.CivicsApp.ViewModels;
using AZED.CivicsApp.Views;
using Xamarin.Forms;
using AZED.CivicsApp.Services;


namespace AZED.CivicsApp
{
    public partial class App : Application
    {

		//static QuizAttemptDataService database;

        public App()
        {
            
            InitializeComponent();

            var navService = ConfigurationUtility.ConfigureNavigationService();



            //var mainPage = new NavigationPage(new MainPage());

            //navService.Initialize(mainPage);

            //MainPage = mainPage;


            //DISABLED ONLY FOR DATABASE TEST
            MainPage = new MasterTabbedNavPage();   



            //ONLY FOR DATABASE TEST
			//MainPage = new NavigationPage(new AltChooseQuizSectionPage());
        }


        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                return _locator ?? (_locator = new ViewModelLocator());
            }
        }
        

     //   public static QuizAttemptDataService Database
     //   {
     //       get
     //       {
     //           if (database == null)
     //           {
					//database = new QuizAttemptDataService(DependencyService.Get<ILocalFileHelper>().GetLocalFilePath("QuizAttempts.db3"));
        //        }
        //        return database;
        //    }
        //}


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }




    }
}
