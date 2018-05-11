using AZED.CivicsApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Linq;
using System.Linq;
using AZED.CivicsApp.Contracts;
using GalaSoft.MvvmLight.Ioc;

namespace AZED.CivicsApp.Services
{
    public class QuestionAnswerDataService : IQuestionAnswerDataService
    {
        XDocument xDoc = new XDocument();

        [PreferredConstructor]
        public QuestionAnswerDataService()
        {
            var fileStream = ReadFileFromAssemblyResource();
            this.LoadXmlFile(fileStream);
        }

        public QuestionAnswerDataService(Stream fileStream)
        {
            this.LoadXmlFile(fileStream);
        }


        private Stream ReadFileFromAssemblyResource()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly; ;
            return assembly.GetManifestResourceStream("AZED.CivicsApp.Data.QuestionsAnswers.xml");
        }

        private void LoadXmlFile(Stream stream)
        {
            using (var reader = new System.IO.StreamReader(stream))
            {
                this.xDoc = XDocument.Load(reader);
            }
        }

        private IEnumerable<QuestionAnswer> GetQuestionAnswerElements()
        {
            return this.xDoc.Root.Descendants("QuestionAnswer")
                            .Select(x => new QuestionAnswer()
                            {
                                AdeID = x.Attribute("AdeID").Value,
                                AdeNumber = x.Attribute("AdeNumber").Value,
                                AdeQuestion = x.Attribute("AdeQuestion").Value,
                                AdeAnswer = x.Attribute("AdeAnswer").Value,
                                AdeStandard = x.Attribute("AdeStandard").Value,
                                AdeGrade = x.Attribute("AdeGrade").Value,
                                AdeSubject = x.Attribute("AdeSubject").Value,
                                UscisSection = x.Attribute("UscisSection").Value,
                                UscisSubsection = x.Attribute("UscisSubsection").Value,
                                UscisNumber = x.Attribute("UscisNumber").Value,
                                AdeChoiceA = x.Attribute("AdeChoiceA").Value,
                                AdeChoiceB = x.Attribute("AdeChoiceB").Value,
                                AdeChoiceC = x.Attribute("AdeChoiceC").Value,
                                AdeChoiceD = x.Attribute("AdeChoiceD").Value
                            });
        }

        public List<QuestionAnswer> GetAllQuestionsAnswersFromSection(string section)
        {
            var questions = this.GetQuestionAnswerElements()
                                .Where(x => x.UscisSection.Equals(section, StringComparison.CurrentCultureIgnoreCase))
                                .ToList();

            return questions;
        }

        public List<QuestionAnswer> GetRandomQuestionsAnswersFromSection(string section, int numberOfQuestionsToReturn)
        {
            var questions = this.GetQuestionAnswerElements()
                                .Where(x => x.UscisSection.Equals(section, StringComparison.CurrentCultureIgnoreCase))
                                .OrderBy(x => Guid.NewGuid())       //randomizes the list order. each guid is unique and will not follow any sequence
                                .Take(numberOfQuestionsToReturn)
                                .ToList();

            return questions;
        }
    }
}
