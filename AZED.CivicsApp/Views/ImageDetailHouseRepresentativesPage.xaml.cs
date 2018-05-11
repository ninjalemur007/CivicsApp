using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailHouseRepresentativesPage : ContentPage
    {
        public ImageDetailHouseRepresentativesPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
