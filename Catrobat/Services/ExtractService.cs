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
                    string path = string.Format("{0}\\{1}", destPath, Guid.NewGuid());
                    using (ZipArchive archive = ZipFile.Open(f, ZipArchiveMode.Read))
                    {
                        archive.ExtractToDirectory(path);
                    }
                    File.Delete(f);
                    CorrectXml(path);
                }
            }
        }

        private void CorrectXml(string path)
        {
            foreach (string f in Directory.GetFiles(path))
            {
                if (f.EndsWith("code.xml"))
                {
                    string s;
                    using (var read = new StreamReader(File.Open(f, FileMode.Open)))
                    {
                        s = read.ReadToEnd();
                        s = s.Replace("<program>", "<program xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
                        s = s.Replace(" type=\"", " xsi:type=\"");
                    }
                    using (var stream = new StreamWriter(new FileStream(f, FileMode.Create, FileAccess.Write)))
                    {
                        stream.Write(s);
                    }
                }
            }
        }
    }
}
