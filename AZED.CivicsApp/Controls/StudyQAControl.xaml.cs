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
    public partial class StudyQAControl : ContentView
    {
        public StudyQAControl()
        {
            InitializeComponent();
        }


        public static readonly BindableProperty UscisNumberProperty = BindableProperty.Create(nameof(UscisNumber), typeof(string), typeof(StudyQAControl));
        public string UscisNumber
        {
            get { return (string)GetValue(UscisNumberProperty); }
            set { SetValue(UscisNumberProperty, value); }
        }

        public static readonly BindableProperty UscisQuestionProperty = BindableProperty.Create(nameof(UscisQuestion), typeof(string), typeof(StudyQAControl));
        public string UscisQuestion
        {
            get { return (string)GetValue(UscisQuestionProperty); }
            set { SetValue(UscisQuestionProperty, value); }
        }

        public static readonly BindableProperty UscisAnswerProperty = BindableProperty.Create(nameof(UscisAnswer), typeof(string), typeof(StudyQAControl));
        public string UscisAnswer
        {
            get { return (string)GetValue(UscisAnswerProperty); }
            set { SetValue(UscisAnswerProperty, value); }
        }

        public static readonly BindableProperty UscisStudytextProperty = BindableProperty.Create(nameof(UscisStudytext), typeof(string), typeof(StudyQAControl));
        public string UscisStudytext
        {
            get { return (string)GetValue(UscisStudytextProperty); }
            set { SetValue(UscisStudytextProperty, value); }
        }

        public static readonly BindableProperty NextQuestionCommandProperty = BindableProperty.Create(nameof(NextQuestionCommand), typeof(ICommand), typeof(StudyQAControl));

        public ICommand NextQuestionCommand
        {
            get { return (ICommand)GetValue(NextQuestionCommandProperty); }
            set { SetValue(NextQuestionCommandProperty, value); }
        }

        public static readonly BindableProperty NextQuestionCommandParameterProperty = BindableProperty.Create(nameof(NextQuestionCommandParameter), typeof(object), typeof(StudyQAControl));

        public object NextQuestionCommandParameter
        {
            get { return GetValue(NextQuestionCommandParameterProperty); }
            set { SetValue(NextQuestionCommandParameterProperty, value); }
        }

        public static readonly BindableProperty PreviousQuestionCommandProperty = BindableProperty.Create(nameof(PreviousQuestionCommand), typeof(ICommand), typeof(StudyQAControl));

        public ICommand PreviousQuestionCommand
        {
            get { return (ICommand)GetValue(PreviousQuestionCommandProperty); }
            set { SetValue(PreviousQuestionCommandProperty, value); }
        }

        public static readonly BindableProperty PreviousQuestionCommandParameterProperty = BindableProperty.Create(nameof(PreviousQuestionCommandParameter), typeof(object), typeof(StudyQAControl));

        public object PreviousQuestionCommandParameter
        {
            get { return GetValue(PreviousQuestionCommandParameterProperty); }
            set { SetValue(PreviousQuestionCommandParameterProperty, value); }
        }

        public static readonly BindableProperty ShowAnswerCommandProperty = BindableProperty.Create(nameof(ShowAnswerCommand), typeof(ICommand), typeof(StudyQAControl));

        public ICommand ShowAnswerCommand
        {
            get { return (ICommand)GetValue(ShowAnswerCommandProperty); }
            set { SetValue(ShowAnswerCommandProperty, value); }
        }

    }
}
