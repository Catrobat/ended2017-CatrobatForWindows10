using Catrobat_Player.NativeComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class @object : IObject
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<ILook> Looks
        {
            get { return this.lookList.Cast<ILook>().ToList(); }
            set { }
        }

        [XmlIgnore]
        public string Name
        {
            get { return this.name; }
            set { }
        }

        [XmlIgnore]
        public IList<IScript> Scripts
        {
            get { return this.scriptList.Cast<IScript>().ToList(); }
            set { }
        }

        [XmlIgnore]
        public IList<IUserVariable> UserVariables
        {
            get { return new List<IUserVariable>(); }
            set { }
        }
        #endregion

    }
}
