using Catrobat.Common;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class UserVariable : IUserVariable
    {
        #region NativeComponent
        [XmlIgnore]
        public string Name
        {
            get
            {
                return Value;
            }
            set { }
        }
        #endregion

    }
}
