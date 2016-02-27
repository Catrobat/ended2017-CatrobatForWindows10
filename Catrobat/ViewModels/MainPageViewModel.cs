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

        public bool IsLoading
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
            IsLoading = t == DownloadStatus.Started ? true : false;
            if (t == DownloadStatus.Finished)
            {
                LoadCatrobatPrograms();
            }
        }

        private void LoadCatrobatPrograms()
        {
            CatrobatPrograms.Clear();
            foreach (string f in Directory.GetFiles(Windows.Storage.ApplicationData.Current.LocalFolder.Path))
            {
                CatrobatProgram catProg = new CatrobatProgram();
                using (ZipArchive archive = ZipFile.Open(f, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        if (entry.FullName == "automatic_screenshot.png" ||
                            entry.FullName == "manual_screenshot.png")
                        {
                            using (MemoryStream m = new MemoryStream())
                            {
                                var bitmap = new BitmapImage();
                                entry.Open().CopyTo(m);
                                m.Position = 0;
                                bitmap.SetSource(m.AsRandomAccessStream());
                                catProg.Thumbnail = bitmap;
                            }
                        }
                        else if (entry.FullName == "code.xml")
                        {
                            Stream s = entry.Open();
                        }
                        else if (entry.FullName.StartsWith("images", StringComparison.OrdinalIgnoreCase) &&
                            entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                        {
                            Stream s = entry.Open();
                        }
                        else if (entry.FullName.StartsWith("sounds", StringComparison.OrdinalIgnoreCase) &&
                            entry.FullName.EndsWith(".m4a", StringComparison.OrdinalIgnoreCase))
                        {
                            Stream s = entry.Open();
                        }
                    }
                }
                CatrobatPrograms.Add(catProg);
            }
        }

    }
}
