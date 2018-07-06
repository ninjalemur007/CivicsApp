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
	public partial class StudyPage : ContentPage
	{

        public StudyPage()
		{
			InitializeComponent ();

            BindingContext = App.Locator.GetViewModel(this);

			On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        //Study Info Icon
        async void infoStudy(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InfoStudyPage());
        }


        //SectionCard 1
        async void GoToInfoI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionOneInfoPage());
        }

        async void GoToSectionI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudySectionOnePage());
        }

        //SectionCard 2
        async void GoToInfoII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionTwoInfoPage());
        }

        async void GoToSectionII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudySectionTwoPage());
        }


        //SectionCard 3
        async void GoToInfoIII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionThreeInfoPage());
        }

        async void GoToSectionIII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudySectionThreePage());
        }

        //StudyRecommendations Button
        async void GoToStudyRecommendations(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage());
        }
        

    }
}