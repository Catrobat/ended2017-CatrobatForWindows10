using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v0992
{
    partial class SetXBrick : ISetXBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree PositionX
        {
            get { return formulaList.FirstOrDefault(x => x.category == "X_POSITION"); }
            set { }
        }
        #endregion

    }
}
