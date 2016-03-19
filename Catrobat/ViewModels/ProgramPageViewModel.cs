using Catrobat.Models;
using Catrobat.Repositories;
using Microsoft.Practices.Unity.Utility;
using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Collections.Generic;

namespace Catrobat.ViewModels
{
    class ProgramPageViewModel : ViewModelBase
    {
        #region Private fields
        private string _catrobatProgramId;
        #endregion

        #region Public properties
        #endregion

        #region Commands
        public DelegateCommand PlayCommand { get; set; }

        #endregion

        public ProgramPageViewModel(INavigationService navService, 
                                    EventAggregator eventAggregator)
        {
            PlayCommand = new DelegateCommand(() =>
            {
                navService.Navigate(CatrobatPage.Player.ToString(), _catrobatProgramId);
            });
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
            _catrobatProgramId = e.Parameter as string;
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

    }
}
