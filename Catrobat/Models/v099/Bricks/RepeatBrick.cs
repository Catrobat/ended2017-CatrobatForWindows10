using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v099
{
    partial class RepeatBrick : IRepeatBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree TimesToRepeat
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "TIMES_TO_REPEAT");
            }
            set { }
        }
        #endregion
    }
}
