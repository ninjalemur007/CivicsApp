using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class InfoStudyPage : ContentPage
    {
        public InfoStudyPage()
        {
            InitializeComponent();
        }

        async void reversePopup(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
