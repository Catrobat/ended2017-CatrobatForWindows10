using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;
using System;

namespace Catrobat.Models.v099
{
    partial class GlideToBrick : IGLideToBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree DestinationX
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "X_DESTINATION");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree DestinationY
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
