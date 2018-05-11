using AZED.CivicsApp.Contracts;
using AZED.CivicsApp.Models;
using AZED.CivicsApp.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.ComponentModel;

namespace AZED.CivicsApp.ViewModels
{
    public class StudyQAViewModel : AppViewModelBase
    {

        private List<Section> sections = new List<Section>();
        private List<Subsection> subsections = new List<Subsection>();
        private List<StudyQuestion> studyQuestions = new List<StudyQuestion>();

        private readonly ISectionDataService sectionDataService;
        private readonly ISubsectionDataService subsectionDataService;
        private readonly INavigationService navigationService;
        private readonly IStudyDataService studyDataService;

        public ICommand PassSectionDesignatorCommand { get; private set; }
        public ICommand ShowAnswerCommand { get; private set; }

        #region properties

        private Section currentSection;
        public Section CurrentSection
        {
            get
            {
                return currentSection;
            }
            set
            {
                if (Set(() => CurrentSection, ref currentSection, value))
                {
                    RaisePropertyChanged(() => CurrentSection);
                }
            }
        }


        private Subsection currentSubsection;
        public Subsection CurrentSubsection
        {
            get
            {
                return currentSubsection;
            }
            set
            {
                if (Set(() => CurrentSubsection, ref currentSubsection, value))
                {
                    RaisePropertyChanged(() => CurrentSubsection);
                }
            }
        }


        private StudyQuestion currentStudyQuestion;
        public StudyQuestion CurrentStudyQuestion
        {
            get
            {
                return currentStudyQuestion;
            }
            set
            {
                if (Set(() => CurrentStudyQuestion, ref currentStudyQuestion, value))
                {
                    RaisePropertyChanged(() => CurrentStudyQuestion);
                }
            }
        }

        private string currentStudyQuestionNumberText;
        public string CurrentStudyQuestionNumberText
        {
            get
            {
                return currentStudyQuestionNumberText;
            }
            set
            {
                if (Set(() => CurrentStudyQuestionNumberText, ref currentStudyQuestionNumberText, value))
                {
                    RaisePropertyChanged(() => CurrentStudyQuestionNumberText);
                }
            }
        }


        private int numberStudyQuestions;
        public int NumberStudyQuestions
        {
            get
            {
                return numberStudyQuestions;
            }
            set
            {
                if (Set(() => NumberStudyQuestions, ref numberStudyQuestions, value))
                {
                    RaisePropertyChanged(() => NumberStudyQuestions);
                }
            }
        }

        private int currentStudyQuestionIndex;
        public int CurrentStudyQuestionIndex
        {
            get
            {
                return studyQuestions.Count;
            }
            set
            {
                if (Set(() => CurrentStudyQuestionIndex, ref currentStudyQuestionIndex, value))
                {
                    RaisePropertyChanged(() => CurrentStudyQuestionIndex);
                }
            }
        }

        private bool startStudying;
        public bool StartStudying
        {
            get
            {
                return startStudying;
            }
            set
            {
                if (Set(() => StartStudying, ref startStudying, value))
                {
                    RaisePropertyChanged(() => StartStudying);
                }
            }
        }

        private bool showStudyQuestions;
        public bool ShowStudyQuestions
        {
            get
            {
                return showStudyQuestions;
            }
            set
            {
                if (Set(() => ShowStudyQuestions, ref showStudyQuestions, value))
                {
                    RaisePropertyChanged(() => ShowStudyQuestions);
                }
            }
        }

        private bool showAnswerBoolian;
        public bool ShowAnswerBoolian
        {
            get
            {
                return showAnswerBoolian;
            }
            set
            {
                if (Set(() => ShowAnswerBoolian, ref showAnswerBoolian, value))
                {
                    RaisePropertyChanged(() => ShowAnswerBoolian);
                }
            }
        }

        private bool showAnswerButtonBoolian;
        public bool ShowAnswerButtonBoolian
        {
            get
            {
                return showAnswerButtonBoolian;
            }
            set
            {
                if (Set(() => ShowAnswerButtonBoolian, ref showAnswerButtonBoolian, value))
                {
                    RaisePropertyChanged(() => ShowAnswerButtonBoolian);
                }
            }
        }


        private string passedParameter;
        public string PassedParameter {
            get { return passedParameter;  }
            set
            {
                if (Set(() => PassedParameter, ref passedParameter, value))
                {
                    RaisePropertyChanged(() => PassedParameter);
                }
            }
        }

        #endregion

        #region constructor

        public StudyQAViewModel(ISubsectionDataService subsectionDataService,
                                ISectionDataService sectionDataService,
                                INavigationService navigationService,
                                IStudyDataService studyDataService)
        {

            this.PageTitle = "STUDY Q & A";

           
            this.Initialize();

            this.sectionDataService = sectionDataService;
            this.subsectionDataService = subsectionDataService;
            this.navigationService = navigationService;
            this.studyDataService = studyDataService;

            PassSectionDesignatorCommand = new Command<string>(HelperCommand);

            this.NextQuestionCommand = new RelayCommand(this.NextQuestion, () => this.CanExecuteNextQuestion);
            this.PreviousQuestionCommand = new RelayCommand(this.PreviousQuestion, () => this.CanExecutePreviousQuestion);
            ShowAnswerCommand = new Command(ShowAnswer);
        }


        public void Initialize()
        {

            this.HideQAs();
            this.HideAnswer();
            this.subsections = new List<Subsection>();
            this.studyQuestions = new List<StudyQuestion>();
        }


        #endregion

        #region commands


        void HelperCommand(string newdesignator)
        {
            string theidentifier = newdesignator;
            string[] parts = theidentifier.Split('-');

            var RomanNumeral = parts[0];
            var AlphaLetter = parts[1];

            this.studyQuestions = this.studyDataService.GetAllStudyQuestionsFromSubsection(RomanNumeral, AlphaLetter);

            this.SetNumberStudyQuestions();
            this.SetCurrentSection(RomanNumeral);
            this.SetCurrentSubsection(theidentifier);
            this.SetCurrentStudyQuestion();

            this.ShowQAs();
        }



        public RelayCommand NextQuestionCommand { get; private set; }

        private void NextQuestion()
        {
            this.IncrementCurrentStudyQuestion();
            //this.SetCurrentStudyQuestionNumberText();
            this.SetCurrentStudyQuestion();
            this.EnableDisableNextPreviousCommands();
            this.ShowQAs();
            this.HideAnswer();
        }


        private bool canExecuteNextQuestion;
        public bool CanExecuteNextQuestion
        {
            get { return canExecuteNextQuestion; }
            set
            {
                canExecuteNextQuestion = value;
                RaisePropertyChanged();
                NextQuestionCommand.RaiseCanExecuteChanged();
            }
        }


        public RelayCommand PreviousQuestionCommand { get; private set; }

        private void PreviousQuestion()
        {
            this.DecrementCurrentStudyQuestion();
            //this.SetCurrentStudyQuestionNumberText();
            this.SetCurrentStudyQuestion();
            this.EnableDisableNextPreviousCommands();
            this.ShowQAs();
            this.HideAnswer();
        }

        private bool canExecutePreviousQuestion;
        public bool CanExecutePreviousQuestion
        {
            get { return canExecutePreviousQuestion; }
            set
            {
                canExecutePreviousQuestion = value;
                RaisePropertyChanged();
                PreviousQuestionCommand.RaiseCanExecuteChanged();
            }
        }

        private void ShowAnswer()
        {
            this.ShowAnswerFrame(); 
        }

        private void HideAnswer()
        {
            this.HideAnswerFrame();
        }


    #endregion

    #region private methods

        private void SetCurrentSection(string sectionNumber)
        {
            string sectionidentifer = sectionNumber;
            CurrentSection = this.sectionDataService.GetSection(sectionidentifer);
        }

        private void SetCurrentSubsection(string subsectionIdentifier)
        {
            string subsectionidentifier = subsectionIdentifier;
            this.subsections = this.subsectionDataService.GetSubsection(subsectionidentifier);

            CurrentSubsection = this.subsections[0];
        }

        private void SetCurrentStudyQuestion()
        {
            if (this.studyQuestions.Count > 0)
            {
                CurrentStudyQuestion = this.studyQuestions[this.currentStudyQuestionIndex];
                this.EnableDisableNextPreviousCommands();
            }
            else
            {
                this.CurrentStudyQuestion = null;
            }

        }

        private void ResetCurrentStudyQuestion()
        {
            this.currentStudyQuestionIndex = 0;
        }

        private void IncrementCurrentStudyQuestion()
        {
            //increment index
            if (this.currentStudyQuestionIndex < this.numberStudyQuestions)
                this.currentStudyQuestionIndex++;
        }

        private void DecrementCurrentStudyQuestion()
        {
            //decrement index
            if (this.currentStudyQuestionIndex > 0)
                this.currentStudyQuestionIndex--;
        }

        private void EnableDisableNextPreviousCommands()
        {
            if (this.currentStudyQuestionIndex >= this.numberStudyQuestions - 1)
                this.CanExecuteNextQuestion = false;
            else
                this.CanExecuteNextQuestion = true;


            if (this.currentStudyQuestionIndex <= 0)
                this.CanExecutePreviousQuestion = false;
            else
                this.CanExecutePreviousQuestion = true;

        }



        private void SetCurrentStudyQuestionNumberText()
        {
            this.CurrentStudyQuestionNumberText = string.Format("Question {0} of {1}", this.currentStudyQuestionIndex + 1);
        }

        private void SetNumberStudyQuestions()
        {
            this.NumberStudyQuestions = this.studyQuestions.Count;
        }

        private void HideQAs()
        {
            this.StartStudying = true;
            this.ShowStudyQuestions = false;
        }

        private void ShowQAs()
        {
            this.StartStudying = false;
            this.ShowStudyQuestions = true;
        }

        private void HideAnswerFrame()
        {
            this.ShowAnswerBoolian = false;
            this.ShowAnswerButtonBoolian = true;
        }

        private void ShowAnswerFrame()
        {
            this.ShowAnswerBoolian = true;
            this.ShowAnswerButtonBoolian = false;
        }


        #endregion
    }
}
