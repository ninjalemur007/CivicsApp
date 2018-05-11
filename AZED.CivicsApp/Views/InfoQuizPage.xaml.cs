using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AZED.CivicsApp.Views
{
    public partial class InfoQuizPage : ContentPage
    {
        public InfoQuizPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }

        async void reversePopup(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
