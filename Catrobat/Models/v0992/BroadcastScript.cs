using System;
using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v0992
{
    partial class BroadcastScript : script, IBroadcastScript
    {
        #region NativeComponent
        [XmlIgnore]
        public string Name
        {
            get
            {
                return string.Empty;
            }
            set { }
        }

        [XmlIgnore]
        public string ReceivedMessage
        {
            get
            {
                return receivedMessage ?? string.Empty;
            }
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
