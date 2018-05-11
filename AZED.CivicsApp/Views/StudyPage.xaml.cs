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
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(.5, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.Children.Remove(bigIcon);
                    outerGrid.Children.Remove(studyTitle);
                    outerGrid.Children.Remove(infoIconStudy);
                    outerGrid.Children.Remove(descriptionLabel);
                    outerGrid.Children.Remove(frameSectionCard1);
                    outerGrid.Children.Remove(frameSectionCard2);
                    outerGrid.Children.Remove(frameSectionCard3);
                    outerGrid.Children.Remove(infoIcon1);
                    outerGrid.Children.Remove(infoIcon2);
                    outerGrid.Children.Remove(infoIcon3);
                    outerGrid.Children.Add(bigIcon, 0, 0);
                    outerGrid.Children.Add(studyTitle, 2, 0);
                    outerGrid.Children.Add(infoIconStudy, 3, 0);
                    outerGrid.Children.Add(descriptionLabel, 1, 1);
                    outerGrid.Children.Add(frameSectionCard1, 0, 2);
                    outerGrid.Children.Add(frameSectionCard2, 2, 2);
                    outerGrid.Children.Add(frameSectionCard3, 3, 2);
                    outerGrid.Children.Add(infoIcon1, 1, 2);
                    outerGrid.Children.Add(infoIcon2, 2, 2);
                    outerGrid.Children.Add(infoIcon3, 3, 2);
                    Grid.SetRowSpan(bigIcon, 2);
                    Grid.SetColumnSpan(descriptionLabel, 3);
                    Grid.SetColumnSpan(frameSectionCard1, 2);
                    //outerGrid.Padding = new Thickness(40, 10, 40, 10);
                }
                else
                {
                    outerGrid.RowDefinitions.Clear();
                    outerGrid.ColumnDefinitions.Clear();
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(24, GridUnitType.Absolute) });
                    outerGrid.Children.Remove(bigIcon);
                    outerGrid.Children.Remove(studyTitle);
                    outerGrid.Children.Remove(infoIconStudy);
                    outerGrid.Children.Remove(descriptionLabel);
                    outerGrid.Children.Remove(frameSectionCard1);
                    outerGrid.Children.Remove(frameSectionCard2);
                    outerGrid.Children.Remove(frameSectionCard3);
                    outerGrid.Children.Remove(infoIcon1);
                    outerGrid.Children.Remove(infoIcon2);
                    outerGrid.Children.Remove(infoIcon3);
                    outerGrid.Children.Add(bigIcon, 0, 0);
                    outerGrid.Children.Add(studyTitle, 1, 0);
                    outerGrid.Children.Add(infoIconStudy, 2, 0);
                    outerGrid.Children.Add(descriptionLabel, 1, 1);
                    outerGrid.Children.Add(frameSectionCard1, 0, 2);
                    outerGrid.Children.Add(frameSectionCard2, 0, 3);
                    outerGrid.Children.Add(frameSectionCard3, 0, 4);
                    outerGrid.Children.Add(infoIcon1, 2, 2);
                    outerGrid.Children.Add(infoIcon2, 2, 3);
                    outerGrid.Children.Add(infoIcon3, 2, 4);
                    Grid.SetRowSpan(bigIcon, 2);
                    Grid.SetColumnSpan(frameSectionCard1, 3);
                    Grid.SetColumnSpan(frameSectionCard2, 3);
                    Grid.SetColumnSpan(frameSectionCard3, 3);
                    Grid.SetColumnSpan(descriptionLabel, 2);
                    //outerGrid.Padding = new Thickness(0, 8, 0, 8);
                }
            }
        }



    }
}