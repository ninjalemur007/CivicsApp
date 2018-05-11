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
    public class StudyDataService : IStudyDataService
    {
        XDocument xDoc = new XDocument();

        [PreferredConstructor]
        public StudyDataService()
        {
            var fileStream = ReadFileFromAssemblyResource();
            this.LoadXmlFile(fileStream);
        }

        public StudyDataService(Stream fileStream)
        {
            this.LoadXmlFile(fileStream);
        }


        private Stream ReadFileFromAssemblyResource()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly; ;
            return assembly.GetManifestResourceStream("AZED.CivicsApp.Data.StudyByQuestion.xml");
        }

        private void LoadXmlFile(Stream stream)
        {
            using (var reader = new System.IO.StreamReader(stream))
            {
                this.xDoc = XDocument.Load(reader);
            }
        }

        //Get all StudyQuestion elements and attributes from StudyByQuestion.xml
        private IEnumerable<StudyQuestion> GetStudyQuestionElements()
        {
            return this.xDoc.Root.Descendants("StudyQuestion")
                            .Select(x => new StudyQuestion()
                            {
                                AdeID = x.Attribute("AdeID").Value,
                                SectionNumber = x.Attribute("SectionNumber").Value,
                                SectionTitle = x.Attribute("SectionTitle").Value,
                                SubsectionLetter = x.Attribute("SubsectionLetter").Value,
                                SubsectionTitle = x.Attribute("SubsectionTitle").Value,
                                UscisNumber = x.Attribute("UscisNumber").Value,
                                UscisQuestion = x.Attribute("UscisQuestion").Value,
                                UscisAnswer = x.Attribute("UscisAnswer").Value,
                                UscisStudytext = x.Attribute("UscisStudytext").Value
                            });
        }

        //Get StudyQuestion elements for selected SECTION
        public List<StudyQuestion> GetAllStudyQuestionsFromSection(string sectionnumber)
        {
            var studyquestions = this.GetStudyQuestionElements()
                                .Where(x => x.SectionNumber.Equals(sectionnumber, StringComparison.CurrentCultureIgnoreCase))
                                .ToList();

            return studyquestions;
        }

        //Get StudyQuestion elements for selected SUBSECTION
        public List<StudyQuestion> GetAllStudyQuestionsFromSubsection(string sectionnumber, string subsectionletter)
        {
            var studyquestions = this.GetStudyQuestionElements()
                                .Where(x => x.SectionNumber.Equals(sectionnumber, StringComparison.CurrentCultureIgnoreCase))
                                .Where(x => x.SubsectionLetter.Equals(subsectionletter, StringComparison.CurrentCultureIgnoreCase))
                                .ToList();

            return studyquestions;
        }

        //Get StudyQuestion elements for selected QUESTION
        public List<StudyQuestion> GetStudyQuestion(string uscisnumber)
        {
            var studyquestions = this.GetStudyQuestionElements()
                                .Where(x => x.UscisNumber.Equals(uscisnumber, StringComparison.CurrentCultureIgnoreCase))
                                .ToList();

            return studyquestions;
        }
    }
}
