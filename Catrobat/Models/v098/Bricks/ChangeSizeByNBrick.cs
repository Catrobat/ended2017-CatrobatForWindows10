using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class ChangeSizeByNBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree ChangeSize
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "SIZE_CHANGE");
            }
            set { }
        }
        #endregion

    }
}
