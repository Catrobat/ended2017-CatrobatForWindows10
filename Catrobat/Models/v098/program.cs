using Catrobat_Player.NativeComponent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class program : IProject
    {
        #region NativeComponent
        [XmlIgnore]
        public IHeader Header { get { return this.header; } set { } }

        [XmlIgnore]
        public IList<IObject> Objects
        {
            get { return this.objectList.Cast<IObject>().ToList(); }
            set { }
        }

        [XmlIgnore]
        public IList<IUserVariable> Variables
        {
            get { return new List<IUserVariable>(); }
            set { }
        }
        #endregion

    }
}
