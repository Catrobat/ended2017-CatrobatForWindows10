using Catrobat.Messages;
using Catrobat.Models;
using Catrobat_Player;
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
using Windows.UI.Xaml.Controls;
using Prism.Windows.Navigation;
using Prism.Commands;

namespace Catrobat.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Private fields
        private bool _isLoading = false;
        private CatrobatProgram _selectedCatrobatProgram;
        private INavigationService _navService;

        #endregion

        #region Public properties
        public EventAggregator EventAggregator { get; private set; }

        public ObservableCollection<CatrobatProgram> CatrobatPrograms { get; set; }

        public bool IsDownloading
        {
            get { return _isLoading; }
            private set { base.SetProperty(ref _isLoading, value); }
        }

        public CatrobatProgram SelectedCatrobatProgram
        {
            get { return _selectedCatrobatProgram; }
            set
            {
                _selectedCatrobatProgram = value;

            }
        }

        #endregion
        public DelegateCommand ProgramClickedCommand { get; set; }

        public MainPageViewModel(INavigationService navService, EventAggregator eventAggregator)
        {
            _navService = navService;
            EventAggregator = eventAggregator;
            CatrobatPrograms = new ObservableCollection<CatrobatProgram>();
            EventAggregator.GetEvent<DownloadingMessage>().Subscribe((t) => { Downloading(t); });

            ProgramClickedCommand = new DelegateCommand(() => {
                int a = 1;
            });

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
