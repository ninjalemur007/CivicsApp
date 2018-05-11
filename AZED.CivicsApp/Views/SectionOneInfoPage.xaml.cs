using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AZED.CivicsApp.ViewModels;


namespace AZED.CivicsApp.Views
{
    public partial class SectionOneInfoPage : ContentPage
    {
        public SectionOneInfoPage()
        {
            InitializeComponent();

            BindingContext = App.Locator.GetViewModel(this);

        }

        async void GoToImageDetail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailSigningConstitutionPage());
        }

        async void goBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
