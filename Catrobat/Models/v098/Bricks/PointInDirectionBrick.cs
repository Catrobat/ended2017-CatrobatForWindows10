using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class PointInDirectionBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree VariableFormula
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
