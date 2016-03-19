using System.Collections.Generic;
using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class StartScript : IStartScript, IScript
    {
        #region NativeComponent
        [XmlIgnore]
        public IList<IBrick> Bricks
        {
            get { return new List<IBrick>(); }// return brickList.Cast<IBrick>().ToList(); }
            set { }
        }
        #endregion

    }
}
