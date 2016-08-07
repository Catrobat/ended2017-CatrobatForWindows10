using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class header : IHeader
    {
        #region NativeComponent
        [XmlIgnore]
        public string ApplicationBuildName { get { return this.applicationBuildName; } set { } }

        [XmlIgnore]
        public int ApplicationBuildNumber { get { return this.applicationBuildNumber; } set { } }

        [XmlIgnore]
        public string ApplicationName { get { return this.applicationName; } set { } }

        [XmlIgnore]
        public string ApplicationVersion { get { return this.applicationVersion; } set { } }

        [XmlIgnore]
        public string CatrobatLanguageVersion { get { return this.catrobatLanguageVersion; } set { } }

        [XmlIgnore]
        public string DateTimeUpload { get { return this.dateTimeUpload; } set { } }

        [XmlIgnore]
        public string Description { get { return this.description; } set { } }

        [XmlIgnore]
        public string DeviceName { get { return this.deviceName; } set { } }

        [XmlIgnore]
        public string MediaLicense { get { return this.mediaLicense; } set { } }

        [XmlIgnore]
        public string PlatformVersion { get { return this.platformVersion; } set { } }

        [XmlIgnore]
        public string ProgramLicense { get { return this.programLicense; } set { } }

        [XmlIgnore]
        public string ProgramName { get { return this.programName; } set { } }

        [XmlIgnore]
        public string RemixOf { get { return this.remixOf; } set { } }

        [XmlIgnore]
        public int ScreenHeight { get { return this.screenHeight; } set { } }

        [XmlIgnore]
        public int ScreenWidth { get { return this.screenWidth; } set { } }

        [XmlIgnore]
        public string Tags { get { return this.tags; } set { } }

        [XmlIgnore]
        public string TargetPlatform { get { return this.platform; } set { } }

        [XmlIgnore]
        public string Url { get { return this.url; } set { } }

        [XmlIgnore]
        public string UserHandle { get { return this.userHandle; } set { } }
        #endregion

    }
}
