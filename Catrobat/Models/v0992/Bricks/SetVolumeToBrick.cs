using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class SetVolumeToBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Volume
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "VOLUME");
            }
            set { }
        }
        #endregion

    }
}
