using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class VibrationBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree VibrateDuration
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "VIBRATE_DURATION_IN_SECONDS");
            }
            set { }
        }
        #endregion

    }
}
