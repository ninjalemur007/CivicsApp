using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Views
{
    public partial class SectionThreeInfoPage : ContentPage
    {
        public SectionThreeInfoPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            BindingContext = App.Locator.GetViewModel(this);

        }

        async void GoToImageDetail(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageDetailQuiltPage());
        }

        async void goBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
