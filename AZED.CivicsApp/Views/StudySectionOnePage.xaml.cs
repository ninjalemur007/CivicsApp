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
    public partial class StudySectionOnePage : ContentPage
    {

        public StudySectionOnePage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = App.Locator.GetViewModel(this);

            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

        }

        //Handler for GoToStudyQAPage -> Sends concatenated section & subsection identifier to StudyQAPage
        async void GoToStudyQAPageA(object sender, EventArgs e)
        {
            string identifier = "I-" + cardA.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }

        async void GoToStudyQAPageB(object sender, EventArgs e)
        {
            string identifier = "I-" + cardB.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }

        async void GoToStudyQAPageC(object sender, EventArgs e)
        {
            string identifier = "I-" + cardC.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }

        //Section I Info Page
        async void GoToInfoI(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionOneInfoPage());
        }

        //SectionCard 1 ImageInfo
        async void GoToImageInfoA(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailCrossingDelawarePage());
        }


        //SectionCard 2 ImageInfo
        async void GoToImageInfoB(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailHouseRepresentativesPage());
        }


        //SectionCard 3 ImageInfo
        async void GoToImageInfoC(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailSuffragePage());
        }


        ////StudyRecommendations Button
        //async void GoToStudyRecommendations(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new QuizPage());
        //}


    }
}