using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Catrobat.Models
{
    class CatrobatProgram
    {
        #region Private fields
        private string _storagePath;

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

        #endregion

        public CatrobatProgram(string storagePath)
        {
            _storagePath = storagePath;
        }

    }
}
