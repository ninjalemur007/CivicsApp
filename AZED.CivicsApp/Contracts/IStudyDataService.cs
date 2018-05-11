using AZED.CivicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp.Contracts
{
    public interface IStudyDataService
    {
        List<StudyQuestion> GetAllStudyQuestionsFromSection(string sectionnumber);
        List<StudyQuestion> GetAllStudyQuestionsFromSubsection(string sectionnumber, string subsectionletter);
        List<StudyQuestion> GetStudyQuestion(string uscisnumber);

    }
}