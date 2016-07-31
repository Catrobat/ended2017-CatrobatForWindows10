using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v099
{
    partial class SetSizeToBrick : ISetSizeToBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Scale
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "SIZE");
            }
            set { }
        }
        #endregion
    }
}
