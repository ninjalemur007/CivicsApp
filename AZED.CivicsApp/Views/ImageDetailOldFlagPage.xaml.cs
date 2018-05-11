using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailOldFlagPage : ContentPage
    {
        public ImageDetailOldFlagPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
