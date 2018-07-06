using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using AZED.CivicsApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZED.CivicsApp.ViewModels;

namespace AZED.CivicsApp.Views
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AltQuizPage : ContentPage
    {
          
		public string SectionNumber { get; set; }

		public AltQuizPage(string sectionnumber)
        {
			string passedsectionnumber = sectionnumber;

			SectionNumber = passedsectionnumber;

            InitializeComponent();

			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			//BindingContext = App.Locator.GetViewModel(this);
			AltQuizViewModel viewModel = (AltQuizViewModel)App.Locator.GetViewModel(this);
            //viewModel.Initialize();

            BindingContext = viewModel;
        }

		async void Save_Clicked(object Sender, EventArgs e)
        {         
			BindingContext = new QuizAttempt();
			var attempt = (QuizAttempt)BindingContext;
            await App.Database.SaveQuizAttemptAsync(attempt);
			await Navigation.PushAsync(new QuizAttemptsListPage());
        }
        
        async void Delete_Clicked(object Sender, EventArgs e)
        {
			BindingContext = new QuizAttempt();
            var attempt = (QuizAttempt)BindingContext;
            await App.Database.DeleteQuizAttemptAsync(attempt);
            await Navigation.PopAsync();
        }

		async void GoToList(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new QuizAttemptsListPage());
        }

    }
}
