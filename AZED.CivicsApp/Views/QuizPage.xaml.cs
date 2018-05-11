using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZED.CivicsApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using AZED.CivicsApp.ViewModels;


namespace AZED.CivicsApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class QuizPage : ContentPage
	{


        public QuizPage ()
		{
			InitializeComponent ();

            QuizViewModel viewModel = (QuizViewModel)App.Locator.GetViewModel(this);
            viewModel.Initialize();

            BindingContext = viewModel;
        }

        async void infoQuiz(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InfoQuizPage());
        }

        async void GoToInfoI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionOneInfoPage());
        }

        async void GoToInfoII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionTwoInfoPage());
        }

        async void GoToInfoIII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionThreeInfoPage());
        }

        //async void SaveAndShowQuizResults(object sender, System.EventArgs e)
        //{
        //    var attempt = (QuizAttempt)BindingContext;
        //    await App.Database.SaveQuizAttemptAsync(attempt);
        //    await Navigation.PushAsync(new QuizAttemptsListPage());
        //}


        //private double width = 0;
        //private double height = 0;

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    if (width != this.width || height != this.height)
        //    {
        //        this.width = width;
        //        this.height = height;
        //        if (width > height)
        //        {
        //            cardLayout.Orientation = StackOrientation.Horizontal;
        //        }
        //        else
        //        {
        //            cardLayout.Orientation = StackOrientation.Vertical;
        //        }

        //    }
        //}



    }
}