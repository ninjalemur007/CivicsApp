using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailMississippiRiverPage : ContentPage
    {
        public ImageDetailMississippiRiverPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
