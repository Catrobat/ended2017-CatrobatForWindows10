using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class HideTextBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Y
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "Y_POSITION");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree X
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "X_POSITION");
            }
            set { }
        }
        #endregion

    }
}
