using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class GlideToBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree X
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "X_DESTINATION");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree Y
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "Y_DESTINATION");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree Duration
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "DURATION_IN_SECONDS");
            }
            set { }
        }
        #endregion
    }
}
