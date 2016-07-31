using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class ChangeXByNBrick : IChangeXByBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree OffsetX
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "X_POSITION_CHANGE");
            }
            set { }
        }
        #endregion
    }
}
