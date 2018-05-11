using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AZED.CivicsApp.ViewModels;
namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailSigningConstitutionPage : ContentPage
    {
        public ImageDetailSigningConstitutionPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}


