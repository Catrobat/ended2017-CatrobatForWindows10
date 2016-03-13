using Catrobat_Player.NativeComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class script : IScript
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get
            {
                return new List<IBrick>();
            }
            set { }
        }
        #endregion

    }
}
