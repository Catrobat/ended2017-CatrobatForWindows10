using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class ChangeVolumeByNBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree VariableFormula
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "VOLUME_CHANGE");
            }
            set { }
        }
        #endregion

    }
}
