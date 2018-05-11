using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailCrossingDelawarePage : ContentPage
    {
        public ImageDetailCrossingDelawarePage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
