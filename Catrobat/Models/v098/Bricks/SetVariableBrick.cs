using System;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

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
                // TODO: Fix in player
                return (formulaList != null && formulaList.Length > 0) ? formulaList[0] : null;
            }
            set { }
        }
        #endregion

    }
}
