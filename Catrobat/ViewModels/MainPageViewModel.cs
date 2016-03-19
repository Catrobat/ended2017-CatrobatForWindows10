using Catrobat.Messages;
using Catrobat.Models;
using Prism.Events;
using Prism.Windows.Mvvm;
using System.Collections.ObjectModel;
using Prism.Windows.Navigation;
using Prism.Commands;
using Catrobat.Services;

namespace Catrobat.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Private fields
        private bool _isLoading = false;
        private INavigationService _navService;
        private ProgramService _programService;

        #endregion

        #region Public properties
        public EventAggregator EventAggregator { get; private set; }

        public ObservableCollection<CatrobatProgram> CatrobatPrograms { get; set; }

        public bool IsDownloading
        {
            get { return _isLoading; }
            private set { base.SetProperty(ref _isLoading, value); }
        }

        #endregion

        #region Commands
        public DelegateCommand<CatrobatProgram> ProgramSelectCommand { get; set; }
        #endregion

        public MainPageViewModel(INavigationService navService, 
                                 EventAggregator eventAggregator,
                                 ProgramService programService)
        {
            _navService = navService;
            _programService = programService;
            EventAggregator = eventAggregator;
            CatrobatPrograms = new ObservableCollection<CatrobatProgram>();
            EventAggregator.GetEvent<DownloadingMessage>().Subscribe((t) => { Downloading(t); });

            ProgramSelectCommand = new DelegateCommand<CatrobatProgram>((p) =>
            {
                navService.Navigate(CatrobatPage.Program.ToString(), p /* Just for testing will not work in reality */);
            });

            CatrobatPrograms = new ObservableCollection<CatrobatProgram>(_programService.GetPrograms());
        }

        private void Downloading(DownloadStatus t)
        {
            IsDownloading = t == DownloadStatus.Started ? true : false;
            if (t == DownloadStatus.Finished)
            {
                CatrobatPrograms = new ObservableCollection<CatrobatProgram>(_programService.GetPrograms());
            }
        }

    }
}
