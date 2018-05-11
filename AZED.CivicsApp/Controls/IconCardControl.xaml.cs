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
    public partial class IconCardControl : ContentView
    {
        public IconCardControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IconSourceProperty = BindableProperty.Create(nameof(IconSource), typeof(string), typeof(IconCardControl));
        public string IconSource
        {
            get { return (string)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(IconCardControl));
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(IconCardControl));
        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

    }
}
