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
    public class SectionDataService : ISectionDataService
    {
        XDocument xDoc = new XDocument();

        [PreferredConstructor]
        public SectionDataService()
        {
            var fileStream = ReadFileFromAssemblyResource();
            this.LoadXmlFile(fileStream);
        }

        public SectionDataService(Stream fileStream)
        {
            this.LoadXmlFile(fileStream);
        }


        private Stream ReadFileFromAssemblyResource()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly; ;
            return assembly.GetManifestResourceStream("AZED.CivicsApp.Data.SectionsOutline.xml");
        }

        private void LoadXmlFile(Stream stream)
        {
            using (var reader = new System.IO.StreamReader(stream))
            {
                this.xDoc = XDocument.Load(reader);
            }
        }

        private IEnumerable<Section> GetSectionElements()
        {
            return this.xDoc.Root.Descendants("Section")
                            .Select(x => new Section()
                            {
                                SectionId = x.Attribute("Numeral").Value,
                                Title = x.Attribute("Title").Value,
                                SubSections = x.Elements("Subsection").Select(
                                                    ss =>
                                                    new SubSection()
                                                    {
                                                        SubSectionId = ss.Attribute("Letter").Value,
                                                        Title = ss.Attribute("Title").Value,
                                                    }).ToList()
                            });
        }


        public List<Section> GetAllSections()
        {
            var sections = this.GetSectionElements()
                                .ToList();

            return sections;
        }

        public Section GetSection(string sectionId)
        {
            var section = this.GetSectionElements()
                               .FirstOrDefault(x => x.SectionId.Equals(sectionId, StringComparison.CurrentCultureIgnoreCase));

            return section;
        }

    }
}