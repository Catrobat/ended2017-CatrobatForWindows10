using Catrobat_Player.NativeComponent;
using System.Xml.Serialization;

namespace Catrobat.Models.v099
{
    partial class header : IHeader
    {
        #region NativeComponent
        [XmlIgnore]
        public string ApplicationBuildName { get { return this.applicationBuildName ?? string.Empty; } set { } }

        [XmlIgnore]
        public int ApplicationBuildNumber { get { return this.applicationBuildNumber; } set { } }

        [XmlIgnore]
        public string ApplicationName { get { return this.applicationName ?? string.Empty; } set { } }

        [XmlIgnore]
        public string ApplicationVersion { get { return this.applicationVersion ?? string.Empty; } set { } }

        [XmlIgnore]
        public string CatrobatLanguageVersion { get { return this.catrobatLanguageVersion ?? string.Empty; } set { } }

        [XmlIgnore]
        public string DateTimeUpload { get { return this.dateTimeUpload ?? string.Empty; } set { } }

        [XmlIgnore]
        public string Description { get { return this.description ?? string.Empty; } set { } }

        [XmlIgnore]
        public string DeviceName { get { return this.deviceName ?? string.Empty; } set { } }

        [XmlIgnore]
        public string MediaLicense { get { return this.mediaLicense ?? string.Empty; } set { } }

        [XmlIgnore]
        public string PlatformVersion { get { return this.platformVersion ?? string.Empty; } set { } }

        [XmlIgnore]
        public string ProgramLicense { get { return this.programLicense ?? string.Empty; } set { } }

        [XmlIgnore]
        public string ProgramName { get { return this.programName ?? string.Empty; } set { } }

        [XmlIgnore]
        public string RemixOf { get { return this.remixOf ?? string.Empty; } set { } }

        [XmlIgnore]
        public int ScreenHeight { get { return this.screenHeight; } set { } }

        [XmlIgnore]
        public int ScreenWidth { get { return this.screenWidth; } set { } }

        [XmlIgnore]
        public string Tags { get { return this.tags ?? string.Empty; } set { } }

        [XmlIgnore]
        public string TargetPlatform { get { return this.platform ?? string.Empty; } set { } }

        [XmlIgnore]
        public string Url { get { return this.url ?? string.Empty; } set { } }

        [XmlIgnore]
        public string UserHandle { get { return this.userHandle ?? string.Empty; } set { } }
        #endregion

    }
}
