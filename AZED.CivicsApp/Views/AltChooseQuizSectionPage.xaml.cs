using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using AZED.CivicsApp.Models;
using AZED.CivicsApp.ViewModels;

namespace AZED.CivicsApp.Views
{
	public partial class AltChooseQuizSectionPage : ContentPage
    {

		public AltChooseQuizSectionPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = App.Locator.GetViewModel(this);

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

        }

        //Handler for GoToStudyQAPage -> Sends concatenated section & subsection identifier to StudyQAPage
        async void GoToSectionI(object sender, EventArgs e)
        {
            string identifier = Card1.SectionNumber;
			await Navigation.PushAsync(new AltQuizPage(identifier));
        }

		async void GoToSectionII(object sender, EventArgs e)
        {
            string identifier = Card2.SectionNumber;
			await Navigation.PushAsync(new AltQuizPage(identifier));
        }

		async void GoToSectionIII(object sender, EventArgs e)
        {
            string identifier = Card3.SectionNumber;
			await Navigation.PushAsync(new AltQuizPage(identifier));
        }

        //Info Page
        async void infoQuiz(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new InfoQuizPage());
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
        


    }
}