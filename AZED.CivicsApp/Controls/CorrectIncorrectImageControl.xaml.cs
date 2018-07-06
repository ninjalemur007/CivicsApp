using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorrectIncorrectImageControl : ContentView
    {
        public CorrectIncorrectImageControl()
        {
            InitializeComponent();

            //init the image to empty image first
            correctIncorrectImage.Source = ImageSource.FromFile("AnswerWrong.png");
        }


        public static readonly BindableProperty IsCorrectProperty = BindableProperty.Create(nameof(IsCorrect), typeof(bool), typeof(CorrectIncorrectImageControl), false,
                                                                        propertyChanged: OnIsCorrectPropertyChanged);

        public bool IsCorrect
        {
            get { return (bool)GetValue(IsCorrectProperty); }
            set { SetValue(IsCorrectProperty, value); }
        }

        private static void OnIsCorrectPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //change the image based on the new value
            CorrectIncorrectImageControl control = (CorrectIncorrectImageControl)bindable;

            if ((bool)newValue)
            {
				control.correctIncorrectImage.Source = ImageSource.FromFile("AnswerCorrect.png");
            }
            else
            {
				control.correctIncorrectImage.Source = ImageSource.FromFile("AnswerWrong.png");
            }
        }
    }
}