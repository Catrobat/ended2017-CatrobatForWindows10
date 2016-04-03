using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class script : IScript
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get { return brickList.Cast<IBrick>().ToList(); }
            set { }
        }
        #endregion

    }
}
