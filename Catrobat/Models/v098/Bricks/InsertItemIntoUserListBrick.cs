using Catrobat_Player.NativeComponent;
using System.Linq;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class InsertItemIntoUserListBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public IFormulaTree Index
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "INSERT_ITEM_INTO_USERLIST_INDEX");
            }
            set { }
        }

        [XmlIgnore]
        public IFormulaTree Value
        {
            get
            {
                return formulaList.FirstOrDefault(x => x.category == "INSERT_ITEM_INTO_USERLIST_VALUE");
            }
            set { }
        }
        #endregion

    }
}
