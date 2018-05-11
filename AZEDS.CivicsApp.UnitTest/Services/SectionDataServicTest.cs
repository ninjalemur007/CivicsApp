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
    /// Summary description for SectionDataServiceTest
    /// </summary>
    [TestClass]
    public class SectionDataServiceTest
    {
        public SectionDataServiceTest()
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
            var dataFilePath = Path.Combine(unitTestProjectPath, @"Data\MockSectionsOutline.xml");
            return dataFilePath;
        }

        [TestMethod]
        public void GetAllSections_returns_all_data()
        {
            Stream stream = File.OpenRead(this.GetDataFilePath());

            var dataService = new SectionDataService(stream);

            var sections = dataService.GetAllSections();

            Assert.AreEqual(3, sections.Count);

            Assert.AreEqual("I", sections[0].SectionId);
            Assert.AreEqual("American Government", sections[0].Title);

            Assert.AreEqual(3, sections[0].SubSections.Count);
            Assert.AreEqual("A", sections[0].SubSections[0].SubSectionId);
            Assert.AreEqual("Principles of American Democracy", sections[0].SubSections[0].Title);
        }

        [TestMethod]
        public void GetSection_returns_data_for_section()
        {
            Stream stream = File.OpenRead(this.GetDataFilePath());

            var dataService = new SectionDataService(stream);

            var section = dataService.GetSection("II");

            Assert.IsNotNull(section);

            Assert.AreEqual("II", section.SectionId);
            Assert.AreEqual("American History", section.Title);

            Assert.AreEqual(3, section.SubSections.Count);
            Assert.AreEqual("B", section.SubSections[1].SubSectionId);
            Assert.AreEqual("1800s", section.SubSections[1].Title);
        }
    }
}
