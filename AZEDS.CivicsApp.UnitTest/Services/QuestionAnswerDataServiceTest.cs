using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AZED.CivicsApp.Services;
using System.IO;
using System.Linq;

namespace AZEDS.CivicsApp.UnitTest.Services
{
    /// <summary>
    /// Summary description for QuestionAnswerDataServiceTest
    /// </summary>
    [TestClass]
    public class QuestionAnswerDataServiceTest
    {
        public QuestionAnswerDataServiceTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private string GetDataFilePath()
        {
            var unitTestProjectPath = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName).FullName;
            var dataFilePath = Path.Combine(unitTestProjectPath, @"Data\MockQuestionsAnswers.xml");
            return dataFilePath;
        }

        [TestMethod]
        public void GetAllQuestionsFromSection_returns_all_data_for_section()
        {
            Stream stream = File.OpenRead(this.GetDataFilePath());

            var dataService = new QuestionAnswerDataService(stream);

            var questions = dataService.GetAllQuestionsAnswersFromSection("sec1");

            Assert.AreEqual(2, questions.Count);
            Assert.AreEqual("ade1", questions[0].AdeID);
            Assert.AreEqual("1", questions[0].AdeNumber);
            Assert.AreEqual("sec1", questions[0].UscisSection);
            Assert.AreEqual("A", questions[0].UscisSubsection);
            Assert.AreEqual("101", questions[0].UscisNumber);
            Assert.AreEqual("sec1 q1", questions[0].AdeQuestion);
            Assert.AreEqual("sec1 q1 a1", questions[0].AdeChoiceA);
            Assert.AreEqual("sec1 q1 a2", questions[0].AdeChoiceB);
            Assert.AreEqual("sec1 q1 a3", questions[0].AdeChoiceC);
            Assert.AreEqual("sec1 q1 a4", questions[0].AdeChoiceD);
            Assert.AreEqual("sec1 q1 a4", questions[0].AdeAnswer);
            Assert.AreEqual("S1.C2.O1", questions[0].AdeStandard);
            Assert.AreEqual("1", questions[0].AdeGrade);
            Assert.AreEqual("Government", questions[0].AdeSubject);

            Assert.IsTrue(questions.All(x => x.UscisSection == "sec1"));

        }

        [TestMethod]
        public void GetRandomQuestionsFromSection_top3_returns_3_records()
        {
            Stream stream = File.OpenRead(this.GetDataFilePath());

            var dataService = new QuestionAnswerDataService(stream);

            var questions = dataService.GetRandomQuestionsAnswersFromSection("sec2", 3);

            Assert.AreEqual(3, questions.Count);
            Assert.IsTrue(questions.All(x => x.UscisSection == "sec2"));

        }
    }
}
