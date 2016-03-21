using Catrobat.Models.v098;
using System;
using System.IO;
using System.Xml.Serialization;
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
        public string Id
        {
            get { return _storagePath.Substring(_storagePath.LastIndexOf('\\') + 1); }
        }

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
                using (System.IO.FileStream f = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    try
                    {
                        XmlSerializer xsSubmit = new XmlSerializer(typeof(program));
                        _program = xsSubmit.Deserialize(f) as program;
                    }
                    catch (Exception ex)
                    {
                        // TODO: Remove this!!!
                        (new Windows.UI.Popups.MessageDialog(string.Format("{0}\n{1}", path, ex.Message))).ShowAsync();
                    }
                }
                return _program;
            }
        }

        #endregion

        public CatrobatProgram(string storagePath)
        {
            _storagePath = storagePath;
        }

    }
}
