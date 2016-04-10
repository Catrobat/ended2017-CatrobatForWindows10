using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class MoveNStepsBrick : IMoveNStepsBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Steps
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
