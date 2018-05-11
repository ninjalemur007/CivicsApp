using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Views
{
    public partial class StudySectionThreePage : ContentPage
    {

        public StudySectionThreePage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = App.Locator.GetViewModel(this);

        }

        //Section III Info Page
        async void GoToInfoIII(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SectionOneInfoPage());
        }

        //Handler for GoToStudyQAPage -> Sends concatenated section & subsection identifier to StudyQAPage
        async void GoToStudyQAPageA(object sender, EventArgs e)
        {
            string identifier = "III-" + cardA.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }

        async void GoToStudyQAPageB(object sender, EventArgs e)
        {
            string identifier = "III-" + cardB.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }

        async void GoToStudyQAPageC(object sender, EventArgs e)
        {
            string identifier = "III-" + cardC.SectionNumber;
            await Navigation.PushAsync(new StudyQAPage(identifier));
        }


        //SectionCard 1 ImageInfo
        async void GoToImageInfoA(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailMississippiRiverPage());
        }


        //SectionCard 2 ImageInfo
        async void GoToImageInfoB(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailBetsyRossPage());
        }


        //SectionCard 3 ImageInfo
        async void GoToImageInfoC(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailFourthJulyPage());
        }




        ////StudyRecommendations Button
        //async void GoToStudyRecommendations(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new QuizPage());
        //}


        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                if (width > height)
                {
                    outerGrid.RowDefinitions.Clear();
                    outerGrid.ColumnDefinitions.Clear();
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(24, GridUnitType.Absolute) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(24, GridUnitType.Absolute) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(24, GridUnitType.Absolute) });
                    outerGrid.Children.Remove(descriptionLabel);
                    outerGrid.Children.Remove(sectionInfo);
                    outerGrid.Children.Remove(frameSectionCard1);
                    outerGrid.Children.Remove(frameSectionCard2);
                    outerGrid.Children.Remove(frameSectionCard3);
                    outerGrid.Children.Remove(infoIcon1);
                    outerGrid.Children.Remove(infoIcon2);
                    outerGrid.Children.Remove(infoIcon3);
                    outerGrid.Children.Add(descriptionLabel, 0, 0);
                    outerGrid.Children.Add(sectionInfo, 5, 0);
                    outerGrid.Children.Add(frameSectionCard1, 0, 1);
                    outerGrid.Children.Add(frameSectionCard2, 2, 1);
                    outerGrid.Children.Add(frameSectionCard3, 4, 1);
                    outerGrid.Children.Add(infoIcon1, 1, 1);
                    outerGrid.Children.Add(infoIcon2, 3, 1);
                    outerGrid.Children.Add(infoIcon3, 5, 1);
                    Grid.SetColumnSpan(descriptionLabel, 6);
                    Grid.SetColumnSpan(frameSectionCard1, 2);
                    Grid.SetColumnSpan(frameSectionCard2, 2);
                    Grid.SetColumnSpan(frameSectionCard3, 2);
                }
                else
                {
                    outerGrid.RowDefinitions.Clear();
                    outerGrid.ColumnDefinitions.Clear();
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(24, GridUnitType.Absolute) });
                    outerGrid.Children.Remove(descriptionLabel);
                    outerGrid.Children.Remove(sectionInfo);
                    outerGrid.Children.Remove(frameSectionCard1);
                    outerGrid.Children.Remove(frameSectionCard2);
                    outerGrid.Children.Remove(frameSectionCard3);
                    outerGrid.Children.Remove(infoIcon1);
                    outerGrid.Children.Remove(infoIcon2);
                    outerGrid.Children.Remove(infoIcon3);
                    outerGrid.Children.Add(descriptionLabel, 0, 0);
                    outerGrid.Children.Add(sectionInfo, 1, 0);
                    outerGrid.Children.Add(frameSectionCard1, 0, 1);
                    outerGrid.Children.Add(frameSectionCard2, 0, 2);
                    outerGrid.Children.Add(frameSectionCard3, 0, 3);
                    outerGrid.Children.Add(infoIcon1, 1, 1);
                    outerGrid.Children.Add(infoIcon2, 1, 2);
                    outerGrid.Children.Add(infoIcon3, 1, 3);
                    Grid.SetColumnSpan(frameSectionCard1, 2);
                    Grid.SetColumnSpan(frameSectionCard2, 2);
                    Grid.SetColumnSpan(frameSectionCard3, 2);
                    Grid.SetColumnSpan(descriptionLabel, 2);
                }
            }
        }

    }
}