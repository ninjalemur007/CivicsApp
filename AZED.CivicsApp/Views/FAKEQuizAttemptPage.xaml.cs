using System;
using System.Collections.Generic;
using AZED.CivicsApp.Models;
using AZED.CivicsApp.Data;

using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class FAKEQuizAttemptPage : ContentPage
    {
        public FAKEQuizAttemptPage()
        {
            InitializeComponent();
        }

        async void Save_Clicked(object Sender, EventArgs e)
        {
            var attempt = (QuizAttempt)BindingContext;
            await App.Database.SaveQuizAttemptAsync(attempt);
            await Navigation.PopAsync();
        }

        async void Delete_Clicked(object Sender, EventArgs e)
        {
            var attempt = (QuizAttempt)BindingContext;
            await App.Database.DeleteQuizAttemptAsync(attempt);
            await Navigation.PopAsync();
        }
    }
}
