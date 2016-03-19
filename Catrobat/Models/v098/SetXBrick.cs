using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class SetXBrick : ISetXBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree PositionX
        {
            get { return null; }
            set { }
        }
        #endregion

    }
}
