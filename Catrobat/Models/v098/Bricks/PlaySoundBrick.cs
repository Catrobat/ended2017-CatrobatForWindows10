using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v098
{
    partial class PlaySoundBrick : IPlaySoundBrick
    {
        #region NativeComponent
        [XmlIgnore]
        public string FileName
        {
            get
            {
                return sound.fileName;
            }
            set { }
        }

        [XmlIgnore]
        public string Name
        {
            get
            {
                return sound.name;
            }
            set { }
        }
        #endregion
    }
}
