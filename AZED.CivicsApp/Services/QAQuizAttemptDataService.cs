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
	public class QAQuizAttemptDataService : IQAQuizAttemptDataService
    {
        readonly SQLiteAsyncConnection database;
        
		[PreferredConstructor]
		public QAQuizAttemptDataService()
		{

		}
        
		public QAQuizAttemptDataService(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
			database.CreateTableAsync<QAQuizAttempt>().Wait();

        }



		public Task<List<QAQuizAttempt>> GetQAQuizAttemptsAsync()
        {
			return database.Table<QAQuizAttempt>().ToListAsync();
        }

		public Task<QAQuizAttempt> GetQAQuizAttemptAsync(int id)
        {
			return database.Table<QAQuizAttempt>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

		public Task<int> SaveQAQuizAttemptAsync(QAQuizAttempt qAQuizAttempt)
        {
			if (qAQuizAttempt.ID == 0)
            {
				return database.InsertAsync(qAQuizAttempt);
            }
            else
            {
				return database.UpdateAsync(qAQuizAttempt);
            }
        }

		public Task<int> DeleteQAQuizAttemptAsync(QAQuizAttempt qAQuizAttempt)
        {
			return database.DeleteAsync(qAQuizAttempt);
        }
    }
}
