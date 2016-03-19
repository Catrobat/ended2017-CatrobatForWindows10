﻿using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class look : ILook
    {
        #region NativeComponent
        [XmlIgnore]
        public string FileName
        {
            get { return fileName; }
            set { }
        }

        [XmlIgnore]
        public string Name
        {
            get { return name; }
            set { }
        }

        #endregion

    }
}
