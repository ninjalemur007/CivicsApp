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
    public partial class QuizSectionCardControl : Grid
    {
        public QuizSectionCardControl()
        {
            InitializeComponent();

            this.frameQuizSectionCardControl.GestureRecognizers.Add(new TapGestureRecognizer { Command = TransitionCommand });
        }


        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(QuizSectionCardControl));
        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty SectionNumberProperty = BindableProperty.Create(nameof(SectionNumber), typeof(string), typeof(QuizSectionCardControl));
        public string SectionNumber
        {
            get { return (string)GetValue(SectionNumberProperty); }
            set { SetValue(SectionNumberProperty, value); }
        }

        public static readonly BindableProperty SectionTitleProperty = BindableProperty.Create(nameof(SectionTitle), typeof(string), typeof(QuizSectionCardControl));
        public string SectionTitle
        {
            get { return (string)GetValue(SectionTitleProperty); }
            set { SetValue(SectionTitleProperty, value); }
        }


        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(QuizSectionCardControl));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(QuizSectionCardControl));

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private ICommand TransitionCommand
        {
            get
            {
                return new Command(() =>
                {
                    if (Command != null)
                    {
                        Command.Execute(CommandParameter);
                    }
                });
            }
        }



    }
}