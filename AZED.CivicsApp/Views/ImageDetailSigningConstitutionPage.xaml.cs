using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using AZED.CivicsApp.ViewModels;
namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailSigningConstitutionPage : ContentPage
    {
        public ImageDetailSigningConstitutionPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = new ImageDetailViewModel();  
        }
    }
}


