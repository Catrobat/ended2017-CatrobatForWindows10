using Catrobat.Messages;
using Catrobat.Models;
using Prism.Events;
using Prism.Windows.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Catrobat.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Private fields
        private bool _isLoading = false;

        #endregion

        public EventAggregator EventAggregator { get; private set; }

        public ObservableCollection<CatrobatProgram> CatrobatPrograms { get; set; }

        public bool IsDownloading
        {
            get { return _isLoading; }
            private set { base.SetProperty(ref _isLoading, value); }
        }

        public MainPageViewModel(EventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            CatrobatPrograms = new ObservableCollection<CatrobatProgram>();
            EventAggregator.GetEvent<DownloadingMessage>().Subscribe((t) => { Downloading(t); });

            LoadCatrobatPrograms();
        }

        private void Downloading(DownloadStatus t)
        {
            IsDownloading = t == DownloadStatus.Started ? true : false;
            if (t == DownloadStatus.Finished)
            {
                LoadCatrobatPrograms();
            }
        }

        private void LoadCatrobatPrograms()
        {
            string destPath = string.Format("{0}\\programs", Windows.Storage.ApplicationData.Current.LocalFolder.Path);
            if (!Directory.Exists(destPath)) Directory.CreateDirectory(destPath);

            foreach (string f in Directory.GetFiles(Windows.Storage.ApplicationData.Current.LocalFolder.Path))
            {
                if (f.EndsWith(".zip"))
                {
                    using (ZipArchive archive = ZipFile.Open(f, ZipArchiveMode.Read))
                    {
                        archive.ExtractToDirectory(string.Format("{0}\\{1}", destPath, Guid.NewGuid()));
                    }
                    File.Delete(f);
                }
            }
            CatrobatPrograms.Clear();
            foreach (string storagePath in Directory.GetDirectories(destPath))
            {
                CatrobatPrograms.Add(new CatrobatProgram(storagePath));
            }
        }

    }
}
