using Catrobat.Messages;
using Catrobat.ViewModels;
using Prism.Events;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Catrobat.Views
{
    public sealed partial class MainPage : Page
    {
        private EventAggregator _eventAggregator;

        public MainPage()
        {
            this.InitializeComponent();
            _eventAggregator = (DataContext as MainPageViewModel).EventAggregator;
            (DataContext as MainPageViewModel).MainView = this.MainView;
            WebViewExplore.NavigationStarting += NavigationStarted;
        }

        private async void NavigationStarted(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            if (args.Uri.AbsolutePath.Contains("pocketcode/download/"))
            {
                _eventAggregator.GetEvent<DownloadingMessage>().Publish(DownloadStatus.Started);
                await DownloadProgramAsync(args.Uri);
                _eventAggregator.GetEvent<DownloadingMessage>().Publish(DownloadStatus.Finished);
                args.Cancel = true;
            }
        }

        private static async Task DownloadProgramAsync(Uri requestUri)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
                {
                    using (
                        Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                        stream = new FileStream(string.Format("{0}\\{1}.zip", Windows.Storage.ApplicationData.Current.LocalFolder.Path, 
                        Guid.NewGuid().ToString()), FileMode.Create, FileAccess.Write))
                    {
                        await contentStream.CopyToAsync(stream);
                    }
                }
            }
        }

    }
}
