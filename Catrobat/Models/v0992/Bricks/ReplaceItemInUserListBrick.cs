using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v0992
{
    partial class ReplaceItemInUserListBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Value
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "REPLACE_ITEM_IN_USERLIST_VALUE");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree Index
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "REPLACE_ITEM_IN_USERLIST_INDEX");
            }
            set { }
        }
        #endregion

    }
}
