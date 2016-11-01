using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class ChangeBrightnessByNBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree ChangeBrightness
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "BRIGHTNESS_CHANGE");
            }
            set { }
        }
        #endregion
    }
}
