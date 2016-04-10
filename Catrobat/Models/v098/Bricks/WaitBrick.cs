using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v098
{
    partial class WaitBrick : IWaitBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree TimeToWaitInSeconds
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
