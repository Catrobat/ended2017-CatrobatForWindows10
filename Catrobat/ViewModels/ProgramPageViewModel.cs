using Catrobat.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catrobat.ViewModels
{
    class ProgramPageViewModel : ViewModelBase
    {
        #region Private fields
        private CatrobatProgram _catrobatProgram;
        #endregion

        #region Public properties
        #endregion

        #region Commands
        public DelegateCommand PlayCommand { get; set; }

        #endregion

        public ProgramPageViewModel(INavigationService navService, EventAggregator eventAggregator)
        {
            PlayCommand = new DelegateCommand(() =>
            {
                navService.Navigate(CatrobatPage.Player.ToString(), 
                    _catrobatProgram /* Just for testing will not work in reality */);
            });
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            _catrobatProgram = e.Parameter as CatrobatProgram; // TODO: don't pass complex types
            base.OnNavigatedTo(e, viewModelState);
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

    }
}
