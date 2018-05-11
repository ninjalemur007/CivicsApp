using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp.Models
{
    public class Section
    {
        public string SectionId { get; set; }
        public string Title { get; set; }
        public string DisplayText
        {
            get { return string.Format("{0} {1}", SectionId, Title); }
        }
        public List<SubSection> SubSections { get; set; }
    }

    public class SubSection
    {
        public string SubSectionId { get; set; }
        public string Title { get; set; }
    }
}
