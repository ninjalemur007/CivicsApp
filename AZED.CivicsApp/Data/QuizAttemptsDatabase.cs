using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using AZED.CivicsApp.Models;


namespace AZED.CivicsApp.Data
{
    public class QuizAttemptsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public QuizAttemptsDatabase(string dbPath)
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
