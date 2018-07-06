using AZED.CivicsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace AZED.CivicsApp.Contracts
{
    public interface IQAQuizAttemptDataService
    {
		Task<List<QAQuizAttempt>> GetQAQuizAttemptsAsync();
		Task<QAQuizAttempt> GetQAQuizAttemptAsync(int id);
		Task<int> SaveQAQuizAttemptAsync(QAQuizAttempt qAQuizAttempt);
		Task<int> DeleteQAQuizAttemptAsync(QAQuizAttempt qAQuizAttempt);
    }
}
