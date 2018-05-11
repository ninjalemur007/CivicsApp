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
	public partial class IconTitleDescriptionControl : ContentView
	{
		public IconTitleDescriptionControl()
		{
			InitializeComponent ();

            this.iconTitleDescriptionFrame.GestureRecognizers.Add( new TapGestureRecognizer { Command = TransitionCommand });
        }


        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(IconTitleDescriptionControl));

        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }

        public static readonly BindableProperty DescriptionTextProperty = BindableProperty.Create(nameof(DescriptionText), typeof(string), typeof(IconTitleDescriptionControl));

        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(nameof(ImageSource), typeof(string), typeof(IconTitleDescriptionControl));

        public string ImageSource
        {
            get { return (string)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconTitleDescriptionControl));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(IconTitleDescriptionControl));

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