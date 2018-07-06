using AZED.CivicsApp.Models;
using AZED.CivicsApp.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Linq;


namespace AZED.CivicsApp.Services
{
	public class QuizAttemptDataService : IQuizAttemptDataService
    {
        readonly SQLiteAsyncConnection database;

		[PreferredConstructor]
		public QuizAttemptDataService()
		{

		}

		public QuizAttemptDataService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<QuizAttempt>().Wait();
        }

        public Task<List<QuizAttempt>> GetQuizAttemptsAsync()
        {
            return database.Table<QuizAttempt>().ToListAsync();
        }

        public Task<QuizAttempt> GetQuizAttemptAsync(int id)
        {
            return database.Table<QuizAttempt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveQuizAttemptAsync(QuizAttempt quizAttempt)
        {
            if (quizAttempt.ID == 0)
            {
                return database.InsertAsync(quizAttempt);
            }
            else
            {
                return database.UpdateAsync(quizAttempt);
            }
        }

        public Task<int> DeleteQuizAttemptAsync(QuizAttempt quizAttempt)
        {
            return database.DeleteAsync(quizAttempt);
        }
    }
}
