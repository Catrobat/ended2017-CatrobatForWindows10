using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class RepeatBrick : IRepeatBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree TimesToRepeat
        {
            get
            {
                return formulaList.FirstOrDefault();
            }
            set { }
        }
        #endregion
    }
}
