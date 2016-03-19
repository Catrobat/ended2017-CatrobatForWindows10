using Prism.Events;

namespace Catrobat.Messages
{
    public enum DownloadStatus { Started, Finished }
    class DownloadingMessage : PubSubEvent<DownloadStatus>
    {
    }
}
