using Catrobat.Common;
using System;
using System.IO;
using System.IO.Compression;

namespace Catrobat.Services
{
    class ExtractService
    {
        public void ExtractPrograms()
        {
            string destPath = Constants.PROJECT_PATH;
            if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);

            foreach (string f in Directory.GetFiles(Windows.Storage.ApplicationData.Current.LocalFolder.Path))
            {
                if (f.EndsWith(".zip"))
                {
                    using (ZipArchive archive = ZipFile.Open(f, ZipArchiveMode.Read))
                    {
                        archive.ExtractToDirectory(string.Format("{0}\\{1}", destPath, Guid.NewGuid()));
                    }
                    File.Delete(f);
                }
            }
        }

    }
}
