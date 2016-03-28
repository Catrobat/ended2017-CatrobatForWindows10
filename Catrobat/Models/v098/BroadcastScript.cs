using System;
using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class BroadcastScript : IBroadcastScript
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get
            {
                return brickList.Cast<IBrick>().ToList();
            }
            set { }
        }

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
                return receivedMessage;
            }
            set { }
        }
        #endregion
    }
}
