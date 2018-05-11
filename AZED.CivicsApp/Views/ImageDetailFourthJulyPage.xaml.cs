using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailFourthJulyPage : ContentPage
    {
        public ImageDetailFourthJulyPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
