using System;
using System.Collections.Generic;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;

namespace AZED.CivicsApp.Views
{
    public partial class ImageDetailBetsyRossPage : ContentPage
    {
        public ImageDetailBetsyRossPage()
        {
            InitializeComponent();
            BindingContext = new ImageDetailViewModel();  
        }
    }
}
