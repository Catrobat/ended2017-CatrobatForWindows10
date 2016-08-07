using Catrobat_Player.NativeComponent;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
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
            get
            {
                List<UserVariable> result = new List<UserVariable>();
                foreach (script s in scriptList)
                {
                    if (s is BroadcastScript)
                    {
                        result.AddRange(((BroadcastScript)s).UserVariables);
                    }
                    else if (s is WhenScript)
                    {
                        result.AddRange(((WhenScript)s).UserVariables);
                    }
                    else if (s is StartScript)
                    {
                        result.AddRange(((StartScript)s).UserVariables);
                    }
                }
                return result.Cast<IUserVariable>().ToList();
            }
            set { }
        }
        #endregion

    }
}
