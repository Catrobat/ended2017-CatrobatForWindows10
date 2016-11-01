using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;
using System.Linq;

namespace Catrobat.Models.v0992
{
    partial class SetYBrick : ISetYBrick
    {
        [XmlIgnore]
        public IFormulaTree PositionY
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "Y_POSITION");
            }
            set { }
        }
    }
}
