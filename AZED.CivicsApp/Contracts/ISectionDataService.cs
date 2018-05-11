using AZED.CivicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp.Contracts
{
    public interface ISectionDataService
    {
        List<Section> GetAllSections();
        Section GetSection(string sectionId);
    }
}
