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
    public partial class MainCardControl : ContentView
    {
        public MainCardControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(MainCardControl));
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(MainCardControl));
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(MainCardControl));
        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        private double width = 0;
        private double height = 0;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width != this.width || height != this.height)
            {
                this.width = width;
                this.height = height;
                double product = height / width;
                //if (width > height)
                if (product > .5 )
                {
                    controlGrid.RowDefinitions.Clear();
                    controlGrid.ColumnDefinitions.Clear();
                    controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                    controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                    controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    controlGrid.Children.Remove(titleLabel);
                    controlGrid.Children.Remove(descriptionLabel);
                    controlGrid.Children.Remove(imageObject);
                    controlGrid.Children.Remove(grayBox);
                    controlGrid.Children.Add(titleLabel, 0, 0);
                    controlGrid.Children.Add(grayBox, 0, 2);
                    controlGrid.Children.Add(descriptionLabel, 0, 2);
                    controlGrid.Children.Add(imageObject, 0, 1);
                    titleLabel.HorizontalTextAlignment = TextAlignment.Center;
                }
                else
                {
                    controlGrid.RowDefinitions.Clear();
                    controlGrid.ColumnDefinitions.Clear();
                    controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(3, GridUnitType.Star) });
                    controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
                    controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                    controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
                    controlGrid.Children.Remove(titleLabel);
                    controlGrid.Children.Remove(descriptionLabel);
                    controlGrid.Children.Remove(imageObject);
                    controlGrid.Children.Remove(grayBox);
                    controlGrid.Children.Add (titleLabel, 1, 0);
                    controlGrid.Children.Add(grayBox, 1, 1);
                    controlGrid.Children.Add(descriptionLabel, 1, 1);
                    controlGrid.Children.Add(imageObject, 0, 0);
                    Grid.SetRowSpan(imageObject, 2);
                    titleLabel.HorizontalTextAlignment = TextAlignment.Start;
                }
            }
        }

    }
}
