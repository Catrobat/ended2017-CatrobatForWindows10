using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class PointInDirectionBrick : IPointToBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Rotation
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "DEGREES");
            }
            set { }
        }
        #endregion

    }
}
