using System;
using SQLite;
using AZED.CivicsApp.Data;

namespace AZED.CivicsApp.Models
{
    public class QuizAttempt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime AttemptDateTime { get; set; } = DateTime.Now;

        public string SectionName { get; set; }
       
        public string QuestionID_1 { get; set; }
        public string GivenAnswer_1 { get; set; }
        public string CorrectYN_1 { get; set; }

        public string QuestionID_2 { get; set; }
        public string GivenAnswer_2 { get; set; }
        public string CorrectYN_2 { get; set; }

        public string QuestionID_3 { get; set; }
        public string GivenAnswer_3 { get; set; }
        public string CorrectYN_3 { get; set; }

        public string QuestionID_4 { get; set; }
        public string GivenAnswer_4 { get; set; }
        public string CorrectYN_4 { get; set; }

        public string QuestionID_5 { get; set; }
        public string GivenAnswer_5 { get; set; }
        public string CorrectYN_5 { get; set; }

        public string QuestionID_6 { get; set; }
        public string GivenAnswer_6 { get; set; }
        public string CorrectYN_6 { get; set; }

        public string QuestionID_7 { get; set; }
        public string GivenAnswer_7 { get; set; }
        public string CorrectYN_7 { get; set; }

        public string QuestionID_8 { get; set; }
        public string GivenAnswer_8 { get; set; }
        public string CorrectYN_8 { get; set; }

        public string QuestionID_9 { get; set; }
        public string GivenAnswer_9 { get; set; }
        public string CorrectYN_9 { get; set; }

        public string QuestionID_10 { get; set; }
        public string GivenAnswer_10 { get; set; }
        public string CorrectYN_10 { get; set; }
    }
}
