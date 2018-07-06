using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace AZED.CivicsApp.Models
{
    public class QAQuizAttempt : ObservableObject
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }




        private string adeID;
        public string AdeID
        {
            get
            {
                return adeID;
            }
            set
            {
                if (Set(() => AdeID, ref adeID, value))
                {
                    RaisePropertyChanged(() => AdeID);
                }
            }
        }


        private string adeNumber;
        public string AdeNumber
        {
            get
            {
                return adeNumber;
            }
            set
            {
                if (Set(() => AdeNumber, ref adeNumber, value))
                {
                    RaisePropertyChanged(() => AdeNumber);
                }
            }
        }


        private string adeQuestion;
        public string AdeQuestion
        {
            get
            {
                return adeQuestion;
            }
            set
            {
                if (Set(() => AdeQuestion, ref adeQuestion, value))
                {
                    RaisePropertyChanged(() => AdeQuestion);
                }
            }
        }


        private string adeAnswer;
        public string AdeAnswer
        {
            get
            {
                return adeAnswer;
            }
            set
            {
                if (Set(() => AdeAnswer, ref adeAnswer, value))
                {
                    RaisePropertyChanged(() => AdeAnswer);
                }
            }
        }


        private string adeStandard;
        public string AdeStandard
        {
            get
            {
                return adeStandard;
            }
            set
            {
                if (Set(() => AdeStandard, ref adeStandard, value))
                {
                    RaisePropertyChanged(() => AdeStandard);
                }
            }
        }


        private string adeGrade;
        public string AdeGrade
        {
            get
            {
                return adeGrade;
            }
            set
            {
                if (Set(() => AdeGrade, ref adeGrade, value))
                {
                    RaisePropertyChanged(() => AdeGrade);
                }
            }
        }


        private string adeSubject;
        public string AdeSubject
        {
            get
            {
                return adeSubject;
            }
            set
            {
                if (Set(() => AdeSubject, ref adeSubject, value))
                {
                    RaisePropertyChanged(() => AdeSubject);
                }
            }
        }


        private string uscisSection;
        public string UscisSection
        {
            get
            {
                return uscisSection;
            }
            set
            {
                if (Set(() => UscisSection, ref uscisSection, value))
                {
                    RaisePropertyChanged(() => UscisSection);
                }
            }
        }


        private string uscisSubsection;
        public string UscisSubsection
        {
            get
            {
                return uscisSubsection;
            }
            set
            {
                if (Set(() => UscisSubsection, ref uscisSubsection, value))
                {
                    RaisePropertyChanged(() => UscisSubsection);
                }
            }
        }


        private string uscisNumber;
        public string UscisNumber
        {
            get
            {
                return uscisNumber;
            }
            set
            {
                if (Set(() => UscisNumber, ref uscisNumber, value))
                {
                    RaisePropertyChanged(() => UscisNumber);
                }
            }
        }


        private string adeChoiceA;
        public string AdeChoiceA
        {
            get
            {
                return adeChoiceA;
            }
            set
            {
                if (Set(() => AdeChoiceA, ref adeChoiceA, value))
                {
                    RaisePropertyChanged(() => AdeChoiceA);
                }
            }
        }


        private string adeChoiceB;
        public string AdeChoiceB
        {
            get
            {
                return adeChoiceB;
            }
            set
            {
                if (Set(() => AdeChoiceB, ref adeChoiceB, value))
                {
                    RaisePropertyChanged(() => AdeChoiceB);
                }
            }
        }


        private string adeChoiceC;
        public string AdeChoiceC
        {
            get
            {
                return adeChoiceC;
            }
            set
            {
                if (Set(() => AdeChoiceC, ref adeChoiceC, value))
                {
                    RaisePropertyChanged(() => AdeChoiceC);
                }
            }
        }



        private string adeChoiceD;
        public string AdeChoiceD
        {
            get
            {
                return adeChoiceD;
            }
            set
            {
                if (Set(() => AdeChoiceD, ref adeChoiceD, value))
                {
                    RaisePropertyChanged(() => AdeChoiceD);
                }
            }
        }

        private string givenAnswer;
        public string GivenAnswer
        {
            get
            {
                return givenAnswer;
            }
            set
            {
                if (Set(() => GivenAnswer, ref givenAnswer, value))
                {
                    RaisePropertyChanged(() => GivenAnswer);
                }
            }
        }



        private bool answerChoiceASelected;
        public bool AnswerChoiceASelected
        {
            get
            {
                return answerChoiceASelected;
            }
            set
            {
                givenAnswer = "A";
                userSelectedAnswer = "A";

                if (Set(() => AnswerChoiceASelected, ref answerChoiceASelected, value))
                {
                    RaisePropertyChanged(() => AnswerChoiceASelected);
                    RaisePropertyChanged(() => IsAnswerCorrect);
                    RaisePropertyChanged(() => AnswerChoiceAStatus);
                    RaisePropertyChanged(() => GivenAnswer);
                }
            }
        }


        private bool answerChoiceBSelected;
        public bool AnswerChoiceBSelected
        {
            get
            {
                return answerChoiceBSelected;
            }
            set
            {
                givenAnswer = "B";
                userSelectedAnswer = "B";

                if (Set(() => AnswerChoiceBSelected, ref answerChoiceBSelected, value))
                {
                    RaisePropertyChanged(() => AnswerChoiceBSelected);
                    RaisePropertyChanged(() => IsAnswerCorrect);
                    RaisePropertyChanged(() => AnswerChoiceBStatus);
                    RaisePropertyChanged(() => GivenAnswer);
                }
            }
        }

        private bool answerChoiceCSelected;
        public bool AnswerChoiceCSelected
        {
            get
            {
                return answerChoiceCSelected;
            }
            set
            {
                givenAnswer = "C";
                userSelectedAnswer = "C";

                if (Set(() => AnswerChoiceCSelected, ref answerChoiceCSelected, value))
                {
                    RaisePropertyChanged(() => AnswerChoiceCSelected);
                    RaisePropertyChanged(() => IsAnswerCorrect);
                    RaisePropertyChanged(() => AnswerChoiceCStatus);
                    RaisePropertyChanged(() => GivenAnswer);
                }
            }
        }

        private bool answerChoiceDSelected;
        public bool AnswerChoiceDSelected
        {
            get
            {
                return answerChoiceDSelected;
            }
            set
            {
                givenAnswer = "D";
                userSelectedAnswer = "D";

                if (Set(() => AnswerChoiceDSelected, ref answerChoiceDSelected, value))
                {
                    RaisePropertyChanged(() => AnswerChoiceDSelected);
                    RaisePropertyChanged(() => IsAnswerCorrect);
                    RaisePropertyChanged(() => AnswerChoiceDStatus);
                    RaisePropertyChanged(() => GivenAnswer);
                }
            }
        }







        public AnswerChoiceStatus AnswerChoiceAStatus
        {
            get
            {
                if (AnswerChoiceASelected && IsAnswerCorrect)
                    return AnswerChoiceStatus.CorrectAnswer;
                else if (AnswerChoiceASelected && !IsAnswerCorrect)
                    return AnswerChoiceStatus.IncorrectAnswer;
                else if (AdeAnswer.Equals("A", StringComparison.CurrentCultureIgnoreCase))
                    return AnswerChoiceStatus.AdeCorrectAnswer;
                else
                    return AnswerChoiceStatus.NotSelected;
            }
        }
        public AnswerChoiceStatus AnswerChoiceBStatus
        {
            get
            {
                if (AnswerChoiceBSelected && IsAnswerCorrect)
                    return AnswerChoiceStatus.CorrectAnswer;
                else if (AnswerChoiceBSelected && !IsAnswerCorrect)
                    return AnswerChoiceStatus.IncorrectAnswer;
                else if (AdeAnswer.Equals("B", StringComparison.CurrentCultureIgnoreCase))
                    return AnswerChoiceStatus.AdeCorrectAnswer;
                else
                    return AnswerChoiceStatus.NotSelected;
            }
        }
        public AnswerChoiceStatus AnswerChoiceCStatus
        {
            get
            {
                if (AnswerChoiceCSelected && IsAnswerCorrect)
                    return AnswerChoiceStatus.CorrectAnswer;
                else if (AnswerChoiceCSelected && !IsAnswerCorrect)
                    return AnswerChoiceStatus.IncorrectAnswer;
                else if (AdeAnswer.Equals("C", StringComparison.CurrentCultureIgnoreCase))
                    return AnswerChoiceStatus.AdeCorrectAnswer;
                else
                    return AnswerChoiceStatus.NotSelected;
            }
        }

        public AnswerChoiceStatus AnswerChoiceDStatus
        {
            get
            {
                if (AnswerChoiceDSelected && IsAnswerCorrect)
                    return AnswerChoiceStatus.CorrectAnswer;
                else if (AnswerChoiceDSelected && !IsAnswerCorrect)
                    return AnswerChoiceStatus.IncorrectAnswer;
                else if (AdeAnswer.Equals("D", StringComparison.CurrentCultureIgnoreCase))
                    return AnswerChoiceStatus.AdeCorrectAnswer;
                else
                    return AnswerChoiceStatus.NotSelected;
            }
        }


        private string userSelectedAnswer = string.Empty;


        public bool IsAnswerCorrect
        {
            get
            {
                return userSelectedAnswer.Equals(adeAnswer, StringComparison.CurrentCultureIgnoreCase);
            }
        }


    }

}
