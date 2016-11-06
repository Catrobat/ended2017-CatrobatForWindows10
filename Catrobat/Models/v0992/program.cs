using Catrobat.Common;
using Catrobat_Player.NativeComponent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class program : IProject
    {
        #region NativeComponent
        [XmlIgnore]
        public IHeader Header { get { return header; } set { } }

        [XmlIgnore]
        public IList<IObject> Objects
        {
            get { return scenes.First().objectList.Cast<IObject>().ToList(); } // TODO: We just support one scene
            set { }
        }

        [XmlIgnore]
        public IList<IUserVariable> Variables
        {
            get
            {
                List<IUserVariable> result = new List<IUserVariable>();
                foreach (@object o in scenes.First().objectList) // TODO: We just support one scene
                {
                    result.AddRange(o.UserVariables);
                }
                return result;
            }
            set { }
        }
        #endregion

    }
}
