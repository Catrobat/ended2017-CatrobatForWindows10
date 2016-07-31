using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v099
{
    partial class WaitBrick : IWaitBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree TimeToWaitInSeconds
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "TIME_TO_WAIT_IN_SECONDS");
            }
            set { }
        }
        #endregion
    }
}
