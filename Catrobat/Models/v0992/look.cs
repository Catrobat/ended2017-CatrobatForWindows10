﻿using Catrobat.Common;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class look : ILook
    {
        #region NativeComponent
        [XmlIgnore]
        public string FileName
        {
            get { return fileName ?? string.Empty; }
            set { }
        }

        [XmlIgnore]
        public string Name
        {
            get { return name ?? string.Empty; }
            set { }
        }

        #endregion

    }
}
