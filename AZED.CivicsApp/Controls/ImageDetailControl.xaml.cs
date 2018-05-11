using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDetailControl : ContentView
    {
        public ImageDetailControl()
        {
            InitializeComponent();

        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ImageDetailControl));
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

    }
}
