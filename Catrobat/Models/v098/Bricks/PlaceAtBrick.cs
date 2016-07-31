using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v099
{
    partial class PlaceAtBrick : IPlaceAtBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree PositionX
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "X_POSITION");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree PositionY
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "Y_POSITION");
            }
            set { }
        }
        #endregion

    }
}
