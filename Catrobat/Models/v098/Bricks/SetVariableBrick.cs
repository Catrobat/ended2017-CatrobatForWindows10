using System;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class SetVariableBrick : ISetVariableBrick
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
                return formulaList.FirstOrDefault(x => x.category == "VARIABLE");
            }
            set { }
        }
        #endregion

    }
}
