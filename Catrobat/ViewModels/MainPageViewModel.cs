using Catrobat.Messages;
using Catrobat.Models;
using Prism.Events;
using Prism.Windows.Mvvm;
using System.Collections.ObjectModel;
using Prism.Windows.Navigation;
using Prism.Commands;
using Catrobat.Services;
using Catrobat.Repositories;

namespace Catrobat.ViewModels
{
    class MainPageViewModel : ViewModelBase
    {
        #region Private fields
        private bool _isLoading = false;
        private INavigationService _navService;
        private IRepository<CatrobatProgram> _catrobatProgramRepo;

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
                                 IRepository<CatrobatProgram> catrobatProgramRepository)
        {
            _navService = navService;
            _catrobatProgramRepo = catrobatProgramRepository;
            EventAggregator = eventAggregator;
            CatrobatPrograms = new ObservableCollection<CatrobatProgram>();
            EventAggregator.GetEvent<DownloadingMessage>().Subscribe((t) => { Downloading(t); });

            ProgramSelectCommand = new DelegateCommand<CatrobatProgram>((p) =>
            {
                navService.Navigate(CatrobatPage.Program.ToString(), p.Id);
            });

            CatrobatPrograms = new ObservableCollection<CatrobatProgram>(_catrobatProgramRepo.GetAll());
        }

        private void Downloading(DownloadStatus t)
        {
            IsDownloading = t == DownloadStatus.Started ? true : false;
            if (t == DownloadStatus.Finished)
            {
                CatrobatPrograms = new ObservableCollection<CatrobatProgram>(_catrobatProgramRepo.GetAll());
            }
        }

    }
}
