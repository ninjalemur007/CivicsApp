using System;
using System.Collections.Generic;
using Xamarin.Forms;
using AZED.CivicsApp.ViewModels;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailEmancipationPage : ContentPage
    {
        public ImageDetailEmancipationPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
