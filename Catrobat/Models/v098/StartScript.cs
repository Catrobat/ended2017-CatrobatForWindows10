using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class StartScript : IStartScript, IScript
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get { return brickList.Cast<IBrick>().ToList(); }
            set { }
        }
        #endregion

        [XmlIgnore]
        public List<UserVariable> UserVariables
        {
            get
            {
                List<UserVariable> result = new List<UserVariable>();
                foreach (brick b in brickList)
                {
                    if (b is VariableBrick)
                    {
                        result.Add(((VariableBrick)b).userVariable);
                    }
                }
                return result;
            }
        }

    }
}
