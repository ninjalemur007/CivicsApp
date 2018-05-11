using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AZED.CivicsApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Views
{
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent ();
            BindingContext = App.Locator.GetViewModel(this);
        }

        async void aboutPopup(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InfoTestPage());
        }

    }
}