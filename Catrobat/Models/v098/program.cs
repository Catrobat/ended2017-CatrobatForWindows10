using Catrobat_Player.NativeComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class program : IProject
    {
        #region NativeComponent
        [XmlIgnore]
        public IHeader Header { get { return this.header; } set { } }

        [XmlIgnore]
        public IList<IObject> Objects { get { return new List<IObject>(); } set { } }

        [XmlIgnore]
        public IList<IUserVariable> Variables
        {
            get { return new List<IUserVariable>(); }
            set { }
        }
        #endregion

    }
}
