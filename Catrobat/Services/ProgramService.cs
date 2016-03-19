using Catrobat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Catrobat.Services
{
    class ProgramService
    {
        public IList<CatrobatProgram> GetPrograms()
        {
            string destPath = string.Format("{0}\\Projects", Windows.Storage.ApplicationData.Current.LocalFolder.Path);
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
            List<CatrobatProgram> programs = new List<CatrobatProgram>();
            foreach (string storagePath in Directory.GetDirectories(destPath))
            {
                programs.Add(new CatrobatProgram(storagePath));
            }
            return programs;
        }

    }
}
