using System;
using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class WhenScript : IWhenScript
    {
        #region NativeComponent
        [XmlIgnore]
        public string Action
        {
            get
            {
                return action;
            }
            set { }
        }

        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get
            {
                return brickList.Cast<IBrick>().ToList();
            }
            set { }
        }
        #endregion
    }
}
