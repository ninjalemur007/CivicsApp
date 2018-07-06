using AZED.CivicsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace AZED.CivicsApp.Contracts
{
    public interface IQuizAttemptDataService
    {
		Task<List<QuizAttempt>> GetQuizAttemptsAsync();
		Task<QuizAttempt> GetQuizAttemptAsync(int id);
		Task<int> SaveQuizAttemptAsync(QuizAttempt quizAttempt);
		Task<int> DeleteQuizAttemptAsync(QuizAttempt quizAttempt);
    }
}
