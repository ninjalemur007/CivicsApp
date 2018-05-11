using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            BindingContext = App.Locator.GetViewModel(this);

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
                }
                else
                {
                }
            }
        }


        async void GoToStudy(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StudyPage());
        }

        async void GoToQuiz(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizPage());
        }

        async void GoToTest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TestPage());
        }

        async void GoToMastery(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QuizAttemptsListPage());
        }

    }
}