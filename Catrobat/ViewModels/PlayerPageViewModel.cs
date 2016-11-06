using Catrobat.Repositories;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;
using Catrobat_Player;
using Windows.UI.Xaml.Controls;
using Catrobat.Models;
using Catrobat_Player.NativeComponent;

namespace Catrobat.ViewModels
{
    class PlayerPageViewModel : ViewModelBase
    {
        #region Private fields
        private IRepository<CatrobatProgram> _catrobatProgramRepo;
        private INavigationService _navService;
        private Catrobat_PlayerAdapter _playerObject;

        #endregion

        #region Public properties
        public Page Page { get; set; }

        #endregion

        #region Commands
        #endregion

        public PlayerPageViewModel(INavigationService navService,
                                   IRepository<CatrobatProgram> catrobatProgramRepository)
        {
            _navService = navService;
            _catrobatProgramRepo = catrobatProgramRepository;
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            var p = _catrobatProgramRepo.Get(e.Parameter as string);
            NativeWrapper.SetProject(p.Program);
            _playerObject = new Catrobat_PlayerAdapter();
            _playerObject.InitPlayer(Page, $"{p.Id}\\{p.Program.scenes[0].name}");
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            _playerObject.Dispose();
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

    }
}
