using AZED.CivicsApp.Contracts;
using AZED.CivicsApp.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections.ObjectModel;

namespace AZED.CivicsApp.ViewModels
{
    public class QuizViewModel : AppViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IQuestionAnswerDataService questionAnswerDataService;
        private readonly ISectionDataService sectionDataService;

		//private List<QuestionAnswer> questionsAnswers = new List<QuestionAnswer>();
		private ObservableCollection<QuestionAnswer> questionsAnswers = new ObservableCollection<QuestionAnswer>();
		private int currentQuestionIndex = 0;

        #region properties

        public int MaxNumberOfQuestions
        {
            get
            {
                return 10;
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
				//return string.Format("You answered {0} of the {1} questions correctly", this.CorrectNumberOfQuestions, this.MaxNumberOfQuestions);
				return string.Format("{0} of {1} correct", this.CorrectNumberOfQuestions, this.MaxNumberOfQuestions);
            }
        }

        public string ScorePercent
		{
			get
			{
				int correct = this.CorrectNumberOfQuestions;
				int max = this.MaxNumberOfQuestions;
				double perc = (double)(correct * 100) / max;

				return string.Format("{0}%", perc);
			}
		}

        public string ScorePercentColor
		{
			get
			{
				int correct = this.CorrectNumberOfQuestions;
                int max = this.MaxNumberOfQuestions;
                double perc = (double)(correct * 100) / max;

				if (perc >= 60)
					return "green";
				else return "red";
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

		private bool canShowViewResultsButton;
        public bool CanShowViewResultsButton
		{
			get
			{
				return canShowViewResultsButton;
			}
			set
			{
				if (Set(() => CanShowViewResultsButton, ref canShowViewResultsButton, value))
				{
					RaisePropertyChanged(() => CanShowViewResultsButton);
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

        #endregion

        #region constructor

        public QuizViewModel(INavigationService navigationService,
                             IQuestionAnswerDataService questionAnswerDataService,
                             ISectionDataService sectionDataService)
        {
            this.PageTitle = "Quiz";

            this.Initialize();

            this.navigationService = navigationService;
            this.questionAnswerDataService = questionAnswerDataService;
            this.sectionDataService = sectionDataService;

            this.BeginQuizCommand = new RelayCommand<string>((s) => this.BeginQuiz(s));
            this.NextQuestionCommand = new RelayCommand(this.NextQuestion, () => this.CanExecuteNextQuestion);
            this.PreviousQuestionCommand = new RelayCommand(this.PreviousQuestion, () => this.CanExecutePreviousQuestion);
			//this.ViewResultsCommand = new RelayCommand(this.ViewResults, () => this.CanShowViewResultsButton);
			this.ViewResultsCommand = new RelayCommand(this.ViewResults);
            this.CloseQuizCommand = new RelayCommand(this.CloseQuiz);
            this.ReviewAnswersCommand = new RelayCommand(this.ReviewAnswers);
        }

        public void Initialize()
        {
            this.ShowBeginQuizStep();
			//this.questionsAnswers = new List<QuestionAnswer>();
			this.questionsAnswers = new ObservableCollection<QuestionAnswer>();
        }

        #endregion

        #region commands

        public RelayCommand<string> BeginQuizCommand { get; private set; }

        private void BeginQuiz(string sectionId)
        {
            this.SetCurrentSection(sectionId);

			//this.questionsAnswers = this.questionAnswerDataService.GetRandomQuestionsAnswersFromSection(sectionId, MaxNumberOfQuestions);

			var qaList = this.questionAnswerDataService.GetRandomQuestionsAnswersFromSection(sectionId, MaxNumberOfQuestions);

			foreach (var item in qaList)
			{
				this.questionsAnswers.Add(item);
			}

            this.ResetCurrentQuestionAnswer();
            this.SetCurrentQuestionNumberText();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
            this.ShowHideViewResultsButton();
            this.ShowQuizStep();
        }

        public RelayCommand NextQuestionCommand { get; private set; }

        private void NextQuestion()
        {
            this.IncrementCurrentQuestionAnswer();
            this.SetCurrentQuestionNumberText();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
			this.ShowQuizStep();
			this.ShowHideViewResultsButton();
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
            this.SetCurrentQuestionNumberText();
            this.SetCurrentQuestionAnswer();
            this.EnableDisableNextPreviousCommands();
            this.ShowHideViewResultsButton();
            this.ShowQuizStep();
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
            RaisePropertyChanged(() => CorrectNumberOfQuestions);   //raise event so the property can be reevaluated now
            RaisePropertyChanged(() => ScoreText);                  //raise event so the property can be reevaluated now
			RaisePropertyChanged(() => ScorePercent);
			RaisePropertyChanged(() => ScorePercentColor);
            this.ShowViewResultsStep();
        }


        public RelayCommand ReviewAnswersCommand { get; private set; }

        private void ReviewAnswers()
        {
			this.ShowReviewAnswersStep();
        }

        public RelayCommand CloseQuizCommand { get; private set; }

        private void CloseQuiz()
        {
			this.CanExecuteNextQuestion = true;

			if (this.currentQuestionIndex <= 0)
				this.CanExecutePreviousQuestion = false;
			else
				this.CanExecutePreviousQuestion = true;
            this.navigationService.GoBack();
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


            if (this.currentQuestionIndex <=0)
                this.CanExecutePreviousQuestion = false;
            else
                this.CanExecutePreviousQuestion = true;

        }

        private void SetCurrentQuestionNumberText()
        {
            this.CurrentQuestionNumberText = string.Format("Question {0} of {1}", this.currentQuestionIndex + 1, MaxNumberOfQuestions);
        }

        private void ShowHideViewResultsButton()
        {
			//show the button on the last question
			//if (this.currentQuestionIndex + 1 == MaxNumberOfQuestions)
			//    this.CanShowViewResultsButton = true;
			//else 
			//this.CanShowViewResultsButton = false;
			this.CanShowViewResultsButton = this.currentQuestionIndex + 1 == MaxNumberOfQuestions;
        }

        private void ShowBeginQuizStep()
        {
            this.CanShowBeginQuiz = true;
            this.CanShowQuiz = false;
            this.CanShowViewResults = false;
			this.CanShowReviewAnswers = false;
        }

        private void ShowQuizStep()
        {
            this.CanShowBeginQuiz = false;
            this.CanShowQuiz = true;
            this.CanShowViewResults = false;
			this.CanShowReviewAnswers = false;
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
        }

        #endregion
    }
}
