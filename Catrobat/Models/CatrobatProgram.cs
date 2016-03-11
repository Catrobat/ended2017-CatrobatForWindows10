using Catrobat.Models.v098;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Catrobat.Models
{
    class CatrobatProgram
    {
        #region Private fields
        private string _storagePath;
        private program _program = null;

        #endregion

        #region Public properties
        public string Name { get; set; }

        public BitmapImage Thumbnail
        {
            get
            {
                string pathManual = string.Format("{0}\\manual_screenshot.png", _storagePath);
                string pathAutomatic = string.Format("{0}\\automatic_screenshot.png", _storagePath);
                if (File.Exists(pathManual))
                    return new BitmapImage(new Uri(pathManual));
                else if (File.Exists(pathAutomatic))
                    return new BitmapImage(new Uri(pathAutomatic));
                else
                    return new BitmapImage();
            }
        }

        public program Program
        {
            get
            {
                if (_program != null) return _program;
                string path = string.Format("{0}\\code.xml", _storagePath);
                System.IO.FileStream f = new System.IO.FileStream(path, System.IO.FileMode.Open);
                XmlSerializer xsSubmit = new XmlSerializer(typeof(program));
                return _program = xsSubmit.Deserialize(f) as program;
            }
        }

        #endregion

        public CatrobatProgram(string storagePath)
        {
            _storagePath = storagePath;
        }

    }
}
