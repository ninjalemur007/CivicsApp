using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailBattleLongIslandPage : ContentPage
    {
        public ImageDetailBattleLongIslandPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();       
        }
    }
}
