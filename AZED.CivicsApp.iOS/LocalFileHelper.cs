using System;
using System.IO;
using Xamarin.Forms;
using AZED.CivicsApp.iOS;

[assembly: Dependency(typeof(LocalFileHelper))]
namespace AZED.CivicsApp.iOS
{
    public class LocalFileHelper : ILocalFileHelper
    {
        public string GetLocalFilePath(string fileName)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, fileName);
        }

    }
}
