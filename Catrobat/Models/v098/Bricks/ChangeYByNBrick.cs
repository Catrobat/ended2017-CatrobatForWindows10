using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class ChangeYByNBrick : IChangeYByBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree OffsetY
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "Y_POSITION_CHANGE");
            }
            set { }
        }
        #endregion
    }
}
