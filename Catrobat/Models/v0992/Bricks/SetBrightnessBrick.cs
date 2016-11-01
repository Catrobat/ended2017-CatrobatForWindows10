using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class SetBrightnessBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Brightness
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "BRIGHTNESS");
            }
            set { }
        }
        #endregion

    }
}
