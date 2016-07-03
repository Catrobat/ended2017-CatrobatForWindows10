using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class SetTransparencyBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Transparency
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "TRANSPARENCY");
            }
            set { }
        }
        #endregion
    }
}
