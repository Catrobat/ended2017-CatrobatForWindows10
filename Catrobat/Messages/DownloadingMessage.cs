using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catrobat.Messages
{
    public enum DownloadStatus { Started, Finished }
    class DownloadingMessage : PubSubEvent<DownloadStatus>
    {
    }
}
