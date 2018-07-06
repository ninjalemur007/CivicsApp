using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using AZED.CivicsApp.ViewModels;


namespace AZED.CivicsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudyQAPage : ContentPage
    {

            public string NumberLetter { get; set; }

            public StudyQAPage(string designator)
            {

                string thedesignator = designator;

                NumberLetter = thedesignator;

                InitializeComponent();
                On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

                BindingContext = App.Locator.GetViewModel(this);

		}

        //Study Info Icon
        async void infoStudy(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InfoStudyPage());
        }

	}
}
