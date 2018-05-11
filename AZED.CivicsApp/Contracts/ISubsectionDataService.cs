using AZED.CivicsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AZED.CivicsApp.Contracts
{
    public interface ISubsectionDataService
    {
        List<Subsection> GetSubsection(string sectionNumber);
    }
}
