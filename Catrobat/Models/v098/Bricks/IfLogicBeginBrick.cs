using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class IfLogicBeginBrick : IIfBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Condition
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "IF_CONDITION");
            }
            set { }
        }
        #endregion

    }
}
