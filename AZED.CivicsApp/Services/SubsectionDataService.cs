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
    public class SubsectionDataService : ISubsectionDataService
    {
        XDocument xDoc = new XDocument();

        [PreferredConstructor]
        public SubsectionDataService()
        {
            var fileStream = ReadFileFromAssemblyResource();
            this.LoadXmlFile(fileStream);
        }

        public SubsectionDataService(Stream fileStream)
        {
            this.LoadXmlFile(fileStream);
        }


        private Stream ReadFileFromAssemblyResource()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly; ;
            return assembly.GetManifestResourceStream("AZED.CivicsApp.Data.SubsectionsList.xml");
        }

        private void LoadXmlFile(Stream stream)
        {
            using (var reader = new System.IO.StreamReader(stream))
            {
                this.xDoc = XDocument.Load(reader);
            }
        }

        private IEnumerable<Subsection> GetSubsectionElements()
        {
            return this.xDoc.Root.Descendants("Subsection")
                       .Select(x => new Subsection()
                            {
                                Letter = x.Attribute("Letter").Value,
                                Title = x.Attribute("Title").Value,
                                SectionNumber = x.Attribute("SectionNumber").Value
                            });
        }


        public List<Subsection> GetSubsection(string sectionNumber)
        {
            var subsection = this.GetSubsectionElements()
                                    .Where(x => x.SectionNumber.Equals(sectionNumber, StringComparison.CurrentCultureIgnoreCase))
                                  .ToList();

            return subsection;
        }

    }
}