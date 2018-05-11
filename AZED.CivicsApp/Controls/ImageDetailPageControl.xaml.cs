using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using AZED.CivicsApp.Views;

namespace AZED.CivicsApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImageDetailPageControl : ContentView
    {

        public ImageDetailPageControl()
        {
            InitializeComponent();
        }

        private double width = 0;
        private double height = 0;

		protected override void OnSizeAllocated(double width, double height)
		{
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height) {
                this.width = width;
                this.height = height;
                if (width > height) {
                    outerGrid.RowDefinitions.Clear();
                    outerGrid.ColumnDefinitions.Clear();
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.Children.Remove(frameImageGrid);
                    outerGrid.Children.Remove(detailScroll);
                    outerGrid.Children.Add(frameImageGrid, 0, 0);
                    outerGrid.Children.Add(detailScroll, 1, 0);

                } else {
                    outerGrid.RowDefinitions.Clear();
                    outerGrid.ColumnDefinitions.Clear();
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    outerGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    outerGrid.Children.Remove(frameImageGrid);
                    outerGrid.Children.Remove(detailScroll);
                    outerGrid.Children.Add(frameImageGrid, 0, 0);
                    outerGrid.Children.Add(detailScroll, 0, 1);                }
            }
		}


		public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(ImageDetailPageControl));
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty ImageTitleProperty = BindableProperty.Create(nameof(ImageTitle), typeof(string), typeof(ImageDetailPageControl));
        public string ImageTitle
        {
            get { return (string)GetValue(ImageTitleProperty); }
            set { SetValue(ImageTitleProperty, value); }
        }

        public static readonly BindableProperty ImageArtistProperty = BindableProperty.Create(nameof(ImageArtist), typeof(string), typeof(ImageDetailPageControl));
        public string ImageArtist
        {
            get { return (string)GetValue(ImageArtistProperty); }
            set { SetValue(ImageArtistProperty, value); }
        }

        public static readonly BindableProperty ImageYearProperty = BindableProperty.Create(nameof(ImageYear), typeof(string), typeof(ImageDetailPageControl));
        public string ImageYear
        {
            get { return (string)GetValue(ImageYearProperty); }
            set { SetValue(ImageYearProperty, value); }
        }

        public static readonly BindableProperty ImageMediumProperty = BindableProperty.Create(nameof(ImageMedium), typeof(string), typeof(ImageDetailPageControl));
        public string ImageMedium
        {
            get { return (string)GetValue(ImageMediumProperty); }
            set { SetValue(ImageMediumProperty, value); }
        }

        public static readonly BindableProperty ImageAttributionProperty = BindableProperty.Create(nameof(ImageAttribution), typeof(string), typeof(ImageDetailPageControl));
        public string ImageAttribution
        {
            get { return (string)GetValue(ImageAttributionProperty); }
            set { SetValue(ImageAttributionProperty, value); }
        }

        public static readonly BindableProperty ImageDescriptionProperty = BindableProperty.Create(nameof(ImageDescription), typeof(string), typeof(ImageDetailPageControl));
        public string ImageDescription
        {
            get { return (string)GetValue(ImageDescriptionProperty); }
            set { SetValue(ImageDescriptionProperty, value); }
        }

        public static readonly BindableProperty ShowImageFullScreenProperty = BindableProperty.Create(nameof(ShowImageFullScreen), typeof(ICommand), typeof(ImageDetailPageControl));
        public ICommand ShowImageFullScreen
        {
            get { return (ICommand)GetValue(ShowImageFullScreenProperty); }
            set { SetValue(ShowImageFullScreenProperty, value); }
        }

        public static readonly BindableProperty ShowImageDetailViewProperty = BindableProperty.Create(nameof(ShowImageDetailView), typeof(ICommand), typeof(ImageDetailPageControl));
        public ICommand ShowImageDetailView
        {
            get { return (ICommand)GetValue(ShowImageDetailViewProperty); }
            set { SetValue(ShowImageDetailViewProperty, value); }
        }


        async void goBack(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}
