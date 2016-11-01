//#define NAMESPACE_MISSING_IN_XML
using Catrobat.Common;
using Catrobat.Models.v0992;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
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
                try
                {
                    using (FileStream f = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {

#if NAMESPACE_MISSING_IN_XML
                        // From: http://stackoverflow.com/questions/36138915/xml-namespace-missing-for-parser/36140318#36140318

                        // Load to intermediate XDocument
                        XDocument xDoc;
                        using (var reader = XmlReader.Create(f))
                            xDoc = XDocument.Load(reader);

                        // Fix namespace of "type" attributes
                        XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
                        var l = new List<XElement>(xDoc.Descendants("script"));
                        l.AddRange(xDoc.Descendants("brick"));
                        foreach (var element in l)
                        {
                            var attr = element.Attribute("type");
                            if (attr == null)
                                continue;
                            var newAttr = new XAttribute(xsi + attr.Name.LocalName, attr.Value);
                            attr.Remove();
                            element.Add(newAttr);
                        }

                        // Deserialize directly to final class.
                        _program = xDoc.Deserialize<program>();
                        ReferenceExplorer.LoadReferences(_program);
#else
                        XmlSerializer xsSubmit = new XmlSerializer(typeof(program));
                        _program = xsSubmit.Deserialize(f) as program;
#endif
                    }
                }
                catch (Exception ex)
                {
                    // TODO: Remove this!!!
                    (new Windows.UI.Popups.MessageDialog(string.Format("{0}\n{1}", path, ex.Message))).ShowAsync();
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
