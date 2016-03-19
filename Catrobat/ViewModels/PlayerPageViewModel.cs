using Catrobat.Repositories;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catrobat_Player;
using Windows.UI.Xaml.Controls;
using Catrobat.Models;

namespace Catrobat.ViewModels
{
    class PlayerPageViewModel : ViewModelBase
    {
        #region Private fields
        private IRepository<CatrobatProgram> _catrobatProgramRepo;
        private INavigationService _navService;

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
            Catrobat_Player.NativeComponent.NativeWrapper.SetProject(p.Program);
            Catrobat_PlayerAdapter playerObject = new Catrobat_PlayerAdapter();
            playerObject.InitPlayer(Page, p.Id);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }
    }
}
