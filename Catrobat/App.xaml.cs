using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Prism.Unity.Windows;
using Prism.Events;
using Catrobat.Services;
using Catrobat.Repositories;
using Catrobat.Models;

namespace Catrobat
{
    public enum CatrobatPage { Main, Program, Player }
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : PrismUnityApplication
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
        }

        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(CatrobatPage.Main.ToString(), null);
            return Task.FromResult<object>(null);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(EventAggregator), typeof(EventAggregator), true);
            RegisterTypeIfMissing(typeof(ExtractService), typeof(ExtractService), true);
            RegisterTypeIfMissing(typeof(IRepository<CatrobatProgram>), typeof(CatrobatProgramRepository), true);
        }

    }
}
