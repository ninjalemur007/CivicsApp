using AZED.CivicsApp.Contracts;
using AZED.CivicsApp.Models;
using AZED.CivicsApp.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Windows.Input;
using System.Linq;
using SQLite;
using System.Threading.Tasks;

namespace AZED.CivicsApp.ViewModels
{
    public class AltQuizViewModel : AppViewModelBase
    {

        private readonly IQuestionAnswerDataService questionAnswerDataService;
        private readonly ISectionDataService sectionDataService;
        private readonly INavigationService navigationService;

        private ObservableCollection<QuestionAnswer> questionsAnswers = new ObservableCollection<QuestionAnswer>();
        

        public ICommand PassSectionDesignatorCommand { get; private set; }

        private int currentQuestionIndex = 0;

        #region properties

        public int MaxNumberOfQuestions
        {
            get
            {
                return 2;
            }
        }

		public int CorrectNumberOfQuestions
        {
            get
            {
                return this.questionsAnswers.Where(q => q.IsAnswerCorrect).Count();
            }
        }

        public string ScoreText
        {
            get
            {
                return string.Format("{0} of {1} correct", this.CorrectNumberOfQuestions, this.MaxNumberOfQuestions);
            }
        }


		private string currentQuestionNumberText;
        public string CurrentQuestionNumberText
        {
            get
            {
                return currentQuestionNumberText;
            }
            set
            {
                if (Set(() => CurrentQuestionNumberText, ref currentQuestionNumberText, value))
                {
                    RaisePropertyChanged(() => CurrentQuestionNumberText);
                }
            }
        }
        
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

        private bool canShowBeginQuiz;
        public bool CanShowBeginQuiz
        {
            get
            {
                return canShowBeginQuiz;
            }
            set
            {
                if (Set(() => CanShowBeginQuiz, ref canShowBeginQuiz, value))
                {
                    RaisePropertyChanged(() => CanShowBeginQuiz);
                }
            }
        }

        private bool canShowQuiz;
        public bool CanShowQuiz
        {
            get
            {
                return canShowQuiz;
            }
            set
            {
                if (Set(() => CanShowQuiz, ref canShowQuiz, value))
                {
                    RaisePropertyChanged(() => CanShowQuiz);
                }
            }
        }

		private bool canShowViewResults;
        public bool CanShowViewResults
        {
            get
            {
                return canShowViewResults;
            }
            set
            {
                if (Set(() => CanShowViewResults, ref canShowViewResults, value))
                {
                    RaisePropertyChanged(() => CanShowViewResults);
                }
            }
        }

        private QuestionAnswer currentQuestionAnswer;
        public QuestionAnswer CurrentQuestionAnswer
        {
            get
            {
                return currentQuestionAnswer;
            }
            set
            {
                if (Set(() => CurrentQuestionAnswer, ref currentQuestionAnswer, value))
                {
                    RaisePropertyChanged(() => CurrentQuestionAnswer);
                }
            }
        }
        


        public ObservableCollection<QuestionAnswer> QuestionsAnswerList
        {
            get
            {
                return questionsAnswers;
            }
            set
            {
                if (Set(() => QuestionsAnswerList, ref questionsAnswers, value))
                {
                    RaisePropertyChanged(() => QuestionsAnswerList);
                }
            }
        }


        private string passedParameter;
        public string PassedParameter
        {
            get { return passedParameter; }
            set
            {
                if (Set(() => PassedParameter, ref passedParameter, value))
                {
                    RaisePropertyChanged(() => PassedParameter);
                }
            }
        }

		private bool canShowReviewAnswers;
        public bool CanShowReviewAnswers
        {
            get
            {
                return canShowReviewAnswers;
            }
            set
            {
                if (Set(() => CanShowReviewAnswers, ref canShowReviewAnswers, value))
                {
                    RaisePropertyChanged(() => CanShowReviewAnswers);
                }
            }
        }

		private string q1_AdeID;
        public string Q1_AdeID
        {
            get { return q1_AdeID; }
            //set { if (Set(() => Q1_AdeID, ref q1_AdeID, value)) { RaisePropertyChanged(() => Q1_AdeID); } }
        }
		private string q1_UscisNumber;
		public string Q1_UscisNumber
        {
			get { return q1_UscisNumber; }
			set { if (Set(() => Q1_UscisNumber, ref q1_UscisNumber, value)) { RaisePropertyChanged(() => Q1_UscisNumber); } }
        }
		private string q1_GivenAnswer;
		public string Q1_GivenAnswer
        {
			get { return q1_GivenAnswer; }
			set { if (Set(() => Q1_GivenAnswer, ref q1_GivenAnswer, value)) { RaisePropertyChanged(() => Q1_GivenAnswer); } }
        }
		private string q1_AdeAnswer;
		public string Q1_AdeAnswer
        {
			get { return q1_AdeAnswer; }
			set { if (Set(() => Q1_AdeAnswer, ref q1_AdeAnswer, value)) { RaisePropertyChanged(() => Q1_AdeAnswer); } }
        }

		private string q2_AdeID;
        public string Q2_AdeID
        {
            get { return q2_AdeID; }
            set { if (Set(() => Q2_AdeID, ref q2_AdeID, value)) { RaisePropertyChanged(() => Q2_AdeID); } }
        }
        private string q2_UscisNumber;
        public string Q2_UscisNumber
        {
            get { return q2_UscisNumber; }
            set { if (Set(() => Q2_UscisNumber, ref q2_UscisNumber, value)) { RaisePropertyChanged(() => Q2_UscisNumber); } }
        }
        private string q2_GivenAnswer;
        public string Q2_GivenAnswer
        {
            get { return q2_GivenAnswer; }
            set { if (Set(() => Q2_GivenAnswer, ref q2_GivenAnswer, value)) { RaisePropertyChanged(() => Q2_GivenAnswer); } }
        }
        private string q2_AdeAnswer;
        public string Q2_AdeAnswer
        {
            get { return q2_AdeAnswer; }
            set { if (Set(() => Q2_AdeAnswer, ref q2_AdeAnswer, value)) { RaisePropertyChanged(() => Q2_AdeAnswer); } }
        }


        #endregion

        #region constructor


        public AltQuizViewModel(INavigationService navigationService,
                                IQuestionAnswerDataService questionAnswerDataService,
                                ISectionDataService sectionDataService)
        {
            //this.PageTitle = "ALT QUIZ";

            this.Initialize();

            this.navigationService = navigationService;
            this.questionAnswerDataService = questionAnswerDataService;
            this.sectionDataService = sectionDataService;

            PassSectionDesignatorCommand = new Command<string>(HelperCommand);

            this.NextQuestionCommand = new RelayCommand(this.NextQuestion, () => this.CanExecuteNextQuestion);
            this.PreviousQuestionCommand = new RelayCommand(this.PreviousQuestion, () => this.CanExecutePreviousQuestion);
			this.ViewResultsCommand = new RelayCommand(this.ViewResults);
			this.ReviewAnswersCommand = new RelayCommand(this.ReviewAnswers);

        }


        public void Initialize()
        {
            this.ShowBeginQuizStep();
            this.questionsAnswers = new ObservableCollection<QuestionAnswer>();
        }

        #endregion

        #region commands

        void HelperCommand(string sectionnumber)
        {

            var qaList = this.questionAnswerDataService.GetRandomQuestionsAnswersFromSection(sectionnumber, MaxNumberOfQuestions);

            foreach (var item in qaList)
            {
                this.questionsAnswers.Add(item);
            }
            
			this.SetCurrentQuestionNumberText();

			this.ResetCurrentQuestionAnswer();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
            this.SetCurrentSection(sectionnumber);
            this.ShowQuizStep();
                     
        }
        

        public RelayCommand NextQuestionCommand { get; private set; }

        private void NextQuestion()
        {
            this.IncrementCurrentQuestionAnswer();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
            this.ShowQuizStep();

			this.SetCurrentQuestionNumberText();

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
            this.DecrementCurrentQuestionAnswer();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
            this.ShowQuizStep();

			this.SetCurrentQuestionNumberText();
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

		public RelayCommand ViewResultsCommand { get; private set; }

        private void ViewResults()
        {
            //ShowHideViewResultsButton();
            RaisePropertyChanged(() => CorrectNumberOfQuestions);   //raise event so the property can be reevaluated now
            RaisePropertyChanged(() => ScoreText);                  //raise event so the property can be reevaluated now
            this.ShowViewResultsStep();
        }

		public RelayCommand ReviewAnswersCommand { get; private set; }

        private void ReviewAnswers()
        {
            this.ShowReviewAnswersStep();
        }



        #endregion

        #region private methods

		private void ResetCurrentQuestionAnswer()
        {
            this.currentQuestionIndex = 0;
        }

        private void IncrementCurrentQuestionAnswer()
        {
            //increment index
            if (this.currentQuestionIndex < MaxNumberOfQuestions)
                this.currentQuestionIndex++;
        }

        private void DecrementCurrentQuestionAnswer()
        {
            //decrement index
            if (this.currentQuestionIndex > 0)
                this.currentQuestionIndex--;
        }

        private void SetCurrentQuestionAnswer()
        {
            //set current Question Answer to display to the index
            if (this.questionsAnswers.Count > 0)
            {
                this.CurrentQuestionAnswer = this.questionsAnswers[this.currentQuestionIndex];
            }
            else
            {
                this.CurrentQuestionAnswer = null;
            }
        }


		private void SetCurrentQuestionNumberText()
        {
            this.CurrentQuestionNumberText = string.Format("Question {0} of {1}", this.currentQuestionIndex + 1, MaxNumberOfQuestions);
        }

 

        private void SetCurrentSection(string sectionId)
        {
            this.CurrentSection = this.sectionDataService.GetSection(sectionId);
        }



        private void EnableDisableNextPreviousCommands()
        {
            if (this.currentQuestionIndex >= MaxNumberOfQuestions - 1)
                this.CanExecuteNextQuestion = false;
            else
                this.CanExecuteNextQuestion = true;


            if (this.currentQuestionIndex <= 0)
                this.CanExecutePreviousQuestion = false;
            else
                this.CanExecutePreviousQuestion = true;

        }


        private void ShowBeginQuizStep()
        {
            this.CanShowBeginQuiz = true;
            this.CanShowQuiz = false;
        }

        private void ShowQuizStep()
        {
            this.CanShowQuiz = true;
            this.CanShowBeginQuiz = false;
        }

		private void ShowViewResultsStep()
        {
            this.CanShowBeginQuiz = false;
            this.CanShowQuiz = false;
            this.CanShowViewResults = true;
            this.CanShowReviewAnswers = false;
        }

		private void ShowReviewAnswersStep()
        {
            this.CanShowBeginQuiz = false;
            this.CanShowQuiz = false;
            this.CanShowViewResults = false;
            this.CanShowReviewAnswers = true;
			PopulateQuizAttemptsList();
        }


		private void PopulateQuizAttemptsList()
		{
			ObservableCollection<QuizAttempt> quizAttempts = new ObservableCollection<QuizAttempt>();



			q1_AdeID = this.QuestionsAnswerList[0].AdeID;
			q1_UscisNumber = this.QuestionsAnswerList[0].UscisNumber;
			q1_GivenAnswer = this.QuestionsAnswerList[0].GivenAnswer;
			q1_AdeAnswer = this.QuestionsAnswerList[0].AdeAnswer;

			q2_AdeID = this.QuestionsAnswerList[1].AdeID;
			q2_UscisNumber = this.QuestionsAnswerList[1].UscisNumber;
			q2_GivenAnswer = this.QuestionsAnswerList[1].GivenAnswer;
			q2_AdeAnswer = this.QuestionsAnswerList[1].AdeAnswer;


		}


        #endregion
    }

}
