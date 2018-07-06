using AZED.CivicsApp.Models;
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
    public partial class AnswerStatusImageControl : ContentView
    {
        public AnswerStatusImageControl()
        {
            InitializeComponent();
            //init the image to empty image first
            answerStatusImage.Source = ImageSource.FromResource("AZED.CivicsApp.Resources.answer-notselected.png");
        }
        public static readonly BindableProperty AnswerChoiceStatusProperty = BindableProperty.Create(nameof(AnswerChoiceStatus), typeof(AnswerChoiceStatus), typeof(AnswerStatusImageControl), false,
                                                                        propertyChanged: OnAnswerChoiceStatusPropertyChanged);
        public AnswerChoiceStatus AnswerChoiceStatus
        {
            get { return (AnswerChoiceStatus)GetValue(AnswerChoiceStatusProperty); }
            set { SetValue(AnswerChoiceStatusProperty, value); }
        }
        private static void OnAnswerChoiceStatusPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //change the image based on the new value
            AnswerStatusImageControl control = (AnswerStatusImageControl)bindable;
            switch ((AnswerChoiceStatus)newValue)
            {
                case AnswerChoiceStatus.CorrectAnswer:
                    control.answerStatusImage.Source = ImageSource.FromResource("AZED.CivicsApp.Resources.answer-correct.png");
                    break;
                case AnswerChoiceStatus.IncorrectAnswer:
                    control.answerStatusImage.Source = ImageSource.FromResource("AZED.CivicsApp.Resources.answer-incorrect.png");
                    break;
                default:
                    control.answerStatusImage.Source = ImageSource.FromResource("AZED.CivicsApp.Resources.answer-notselected.png");
                    break;
            }
        }
    }
}