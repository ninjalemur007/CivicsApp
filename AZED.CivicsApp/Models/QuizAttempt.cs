using System;
using SQLite;
using System.Collections.Generic;



namespace AZED.CivicsApp.Models
{
    public class QuizAttempt
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime AttemptDateTime { get; set; } = DateTime.Now;

		[TextBlob("Q1Blobbed")]

		public List<Question> Question1 { get; set; }

		public string Q1Blobbed { get; set; }
    }

	public class Question
    {
        public string AdeID { get; set; }
        public string UscisNumber { get; set; }
        public string GivenAnswer { get; set; }
        public string AdeAnswer { get; set; }
    }
}
