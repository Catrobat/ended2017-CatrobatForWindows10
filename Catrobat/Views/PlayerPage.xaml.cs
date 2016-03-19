using Catrobat.Models;
using Catrobat.Repositories;
using Catrobat.ViewModels;
using Catrobat_Player;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Catrobat.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PlayerPage : Page
    {
        public PlayerPage()
        {
            this.InitializeComponent();
            (this.DataContext as PlayerPageViewModel).Page = this;
        }
    }
}
