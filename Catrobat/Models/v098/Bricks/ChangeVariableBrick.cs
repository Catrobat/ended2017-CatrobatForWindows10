using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class ChangeVariableBrick : IChangeVariableBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IUserVariable Variable
        {
            get
            {
                return userVariable;
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree VariableFormula
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "VARIABLE_CHANGE");
            }
            set { }
        }
        #endregion

    }
}
