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
    public partial class QuestionAnswerControl : ContentView
    {
        public QuestionAnswerControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty SectionTextProperty = BindableProperty.Create(nameof(SectionText), typeof(string), typeof(QuestionAnswerControl));
        public string SectionText
        {
            get { return (string)GetValue(SectionTextProperty); }
            set { SetValue(SectionTextProperty, value); }
        }

        public static readonly BindableProperty QuestionNumberTextProperty = BindableProperty.Create(nameof(QuestionNumberText), typeof(string), typeof(QuestionAnswerControl));
        public string QuestionNumberText
        {
            get { return (string)GetValue(QuestionNumberTextProperty); }
            set { SetValue(QuestionNumberTextProperty, value); }
        }

        public static readonly BindableProperty QuestionTextProperty = BindableProperty.Create(nameof(QuestionText), typeof(string), typeof(QuestionAnswerControl));
        public string QuestionText
        {
            get { return (string)GetValue(QuestionTextProperty); }
            set { SetValue(QuestionTextProperty, value); }
        }

        public static readonly BindableProperty AnswerChoiceATextProperty = BindableProperty.Create(nameof(AnswerChoiceAText), typeof(string), typeof(QuestionAnswerControl));
        public string AnswerChoiceAText
        {
            get { return (string)GetValue(AnswerChoiceATextProperty); }
            set { SetValue(AnswerChoiceATextProperty, value); }
        }

        public static readonly BindableProperty AnswerChoiceBTextProperty = BindableProperty.Create(nameof(AnswerChoiceBText), typeof(string), typeof(QuestionAnswerControl));
        public string AnswerChoiceBText
        {
            get { return (string)GetValue(AnswerChoiceBTextProperty); }
            set { SetValue(AnswerChoiceBTextProperty, value); }
        }

        public static readonly BindableProperty AnswerChoiceCTextProperty = BindableProperty.Create(nameof(AnswerChoiceCText), typeof(string), typeof(QuestionAnswerControl));
        public string AnswerChoiceCText
        {
            get { return (string)GetValue(AnswerChoiceCTextProperty); }
            set { SetValue(AnswerChoiceCTextProperty, value); }
        }

        public static readonly BindableProperty AnswerChoiceDTextProperty = BindableProperty.Create(nameof(AnswerChoiceDText), typeof(string), typeof(QuestionAnswerControl));
        public string AnswerChoiceDText
        {
            get { return (string)GetValue(AnswerChoiceDTextProperty); }
            set { SetValue(AnswerChoiceDTextProperty, value); }
        }


        public static readonly BindableProperty AnswerChoiceAIsCheckedProperty = BindableProperty.Create(nameof(AnswerChoiceAIsChecked), typeof(bool), typeof(QuestionAnswerControl), false,
                                                                                    BindingMode.TwoWay, propertyChanged: OnIsCheckedAPropertyChanged);

        public bool AnswerChoiceAIsChecked
        {
            get { return (bool)GetValue(AnswerChoiceAIsCheckedProperty); }
            set { SetValue(AnswerChoiceAIsCheckedProperty, value); }
        }

        private static void OnIsCheckedAPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //set all other answers to unchecked after this property is checked
            QuestionAnswerControl control = (QuestionAnswerControl)bindable;
            if ((bool)newValue == true)
            {
                control.AnswerChoiceBIsChecked = false;
                control.AnswerChoiceCIsChecked = false;
                control.AnswerChoiceDIsChecked = false;
            }
        }

        public static readonly BindableProperty AnswerChoiceBIsCheckedProperty = BindableProperty.Create(nameof(AnswerChoiceBIsChecked), typeof(bool), typeof(QuestionAnswerControl), false,
                                                                                    BindingMode.TwoWay, propertyChanged: OnIsCheckedBPropertyChanged);
        public bool AnswerChoiceBIsChecked
        {
            get { return (bool)GetValue(AnswerChoiceBIsCheckedProperty); }
            set { SetValue(AnswerChoiceBIsCheckedProperty, value); }
        }

        private static void OnIsCheckedBPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //set all other answers to unchecked after this property is checked
            QuestionAnswerControl control = (QuestionAnswerControl)bindable;
            if ((bool)newValue == true)
            {
                control.AnswerChoiceAIsChecked = false;
                control.AnswerChoiceCIsChecked = false;
                control.AnswerChoiceDIsChecked = false;
            }
        }

        public static readonly BindableProperty AnswerChoiceCIsCheckedProperty = BindableProperty.Create(nameof(AnswerChoiceCIsChecked), typeof(bool), typeof(QuestionAnswerControl), false,
                                                                                    BindingMode.TwoWay, propertyChanged: OnIsCheckedCPropertyChanged);
        public bool AnswerChoiceCIsChecked
        {
            get { return (bool)GetValue(AnswerChoiceCIsCheckedProperty); }
            set { SetValue(AnswerChoiceCIsCheckedProperty, value); }
        }

        private static void OnIsCheckedCPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //set all other answers to unchecked after this property is checked
            QuestionAnswerControl control = (QuestionAnswerControl)bindable;
            if ((bool)newValue == true)
            {
                control.AnswerChoiceAIsChecked = false;
                control.AnswerChoiceBIsChecked = false;
                control.AnswerChoiceDIsChecked = false;
            }
        }

        public static readonly BindableProperty AnswerChoiceDIsCheckedProperty = BindableProperty.Create(nameof(AnswerChoiceDIsChecked), typeof(bool), typeof(QuestionAnswerControl), false,
                                                                                    BindingMode.TwoWay, propertyChanged: OnIsCheckedDPropertyChanged);
        public bool AnswerChoiceDIsChecked
        {
            get { return (bool)GetValue(AnswerChoiceDIsCheckedProperty); }
            set { SetValue(AnswerChoiceDIsCheckedProperty, value); }
        }

        private static void OnIsCheckedDPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //set all other answers to unchecked after this property is checked
            QuestionAnswerControl control = (QuestionAnswerControl)bindable;
            if ((bool)newValue == true)
            {
                control.AnswerChoiceAIsChecked = false;
                control.AnswerChoiceBIsChecked = false;
                control.AnswerChoiceCIsChecked = false;
            }
        }


        public static readonly BindableProperty NextQuestionCommandProperty = BindableProperty.Create(nameof(NextQuestionCommand), typeof(ICommand), typeof(QuestionAnswerControl));

        public ICommand NextQuestionCommand
        {
            get { return (ICommand)GetValue(NextQuestionCommandProperty); }
            set { SetValue(NextQuestionCommandProperty, value); }
        }

        public static readonly BindableProperty NextQuestionCommandParameterProperty = BindableProperty.Create(nameof(NextQuestionCommandParameter), typeof(object), typeof(QuestionAnswerControl));

        public object NextQuestionCommandParameter
        {
            get { return GetValue(NextQuestionCommandParameterProperty); }
            set { SetValue(NextQuestionCommandParameterProperty, value); }
        }

        public static readonly BindableProperty PreviousQuestionCommandProperty = BindableProperty.Create(nameof(PreviousQuestionCommand), typeof(ICommand), typeof(QuestionAnswerControl));

        public ICommand PreviousQuestionCommand
        {
            get { return (ICommand)GetValue(PreviousQuestionCommandProperty); }
            set { SetValue(PreviousQuestionCommandProperty, value); }
        }

        public static readonly BindableProperty PreviousQuestionCommandParameterProperty = BindableProperty.Create(nameof(PreviousQuestionCommandParameter), typeof(object), typeof(QuestionAnswerControl));

        public object PreviousQuestionCommandParameter
        {
            get { return GetValue(PreviousQuestionCommandParameterProperty); }
            set { SetValue(PreviousQuestionCommandParameterProperty, value); }
        }

        public static readonly BindableProperty ViewResultsCommandProperty = BindableProperty.Create(nameof(ViewResultsCommand), typeof(ICommand), typeof(QuestionAnswerControl));

        public ICommand ViewResultsCommand
        {
            get { return (ICommand)GetValue(ViewResultsCommandProperty); }
            set { SetValue(ViewResultsCommandProperty, value); }
        }

        public static readonly BindableProperty ViewResultsCommandParameterProperty = BindableProperty.Create(nameof(ViewResultsCommandParameter), typeof(object), typeof(QuestionAnswerControl));

        public object ViewResultsCommandParameter
        {
            get { return GetValue(ViewResultsCommandParameterProperty); }
            set { SetValue(ViewResultsCommandParameterProperty, value); }
        }
    }
}