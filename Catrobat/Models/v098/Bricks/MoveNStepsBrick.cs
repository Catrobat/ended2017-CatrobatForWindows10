using Catrobat_Player.NativeComponent;
using System.Linq;
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
                return formulaList.FirstOrDefault(x => x.category == "STEPS");
            }
            set { }
        }
        #endregion
    }
}
