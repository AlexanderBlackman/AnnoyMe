using Microsoft.UI.Xaml;
using WinUIEx;
using AnnoyMe.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AnnoyMe
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : WindowEx
    {
        private AcrylicSystemBackdrop acylicBackdrop = new AcrylicSystemBackdrop();
        public MainWindow()
        {
            this.InitializeComponent();
            this.Backdrop = acylicBackdrop;
            this.Title = "red rabbit";
            //this.ExtendsContentIntoTitleBar = true;
            shellFrame.Content = new MainPage();
        }





    }
}
