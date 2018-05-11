using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class InfoTestPage : ContentPage
    {
        public InfoTestPage()
        {
            InitializeComponent();
        }

        async void reversePopup(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
