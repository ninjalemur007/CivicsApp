using AZED.CivicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp.Contracts
{
    public interface IQuestionAnswerDataService
    {
        List<QuestionAnswer> GetAllQuestionsAnswersFromSection(string section);
        List<QuestionAnswer> GetRandomQuestionsAnswersFromSection(string section, int numberOfQuestionsToReturn);
    }
}
