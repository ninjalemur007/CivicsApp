using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AZED.CivicsApp.Controls
{



    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxLabelControl : ContentView
    {
        public CheckBoxLabelControl()
        {
            InitializeComponent();

            //init the image to unchecked first
            checkboxImage.Source = ImageSource.FromFile("CheckboxUnchecked");

            //wire up a tap event for the entire stack panel
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += checkBoxLabel_Tapped;
            this.checkBoxLabelPanel.GestureRecognizers.Add(tapGesture);
        }

        /// <summary>
        /// event listener for the stackpanel tap gesture
        /// </summary>
        private void checkBoxLabel_Tapped(object sender, EventArgs e)
        {
            //negate the IsChecked bindable property
            this.IsChecked = !this.IsChecked;

            //fire an event so the calling class can listen to and take action
            OnCheckChanged(EventArgs.Empty);
        }

        public event EventHandler CheckChanged;
        
        protected virtual void OnCheckChanged(EventArgs e)
        {
            EventHandler handler = CheckChanged;
            if (handler != null)
            {
                // Invokes the delegates.
                handler(this, e);
            }
        }

        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(nameof(LabelText), typeof(string), typeof(CheckBoxLabelControl));

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(CheckBoxLabelControl), false,
                                                                        propertyChanged: OnIsCheckedPropertyChanged);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        private static void OnIsCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //change the check box image based on the new value is true or false
            CheckBoxLabelControl control = (CheckBoxLabelControl)bindable;
           
            if ((bool)newValue)
            {
                control.checkboxImage.Source = ImageSource.FromFile("CheckboxChecked");

            }
            else
            {
                control.checkboxImage.Source = ImageSource.FromFile("CheckboxUnchecked");

            }
        }
    }    
}