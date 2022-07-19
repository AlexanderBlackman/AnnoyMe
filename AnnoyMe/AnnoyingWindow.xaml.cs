using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUIEx;
using AnnoyMe.ViewModels;
using CommunityToolkit.WinUI.Helpers;
using Windows.Graphics.Imaging;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Media.Imaging;
using CommunityToolkit.WinUI;



// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace AnnoyMe
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AnnoyingWindow : WindowEx
    {


        public AnnoyingWindowVM ViewModel { get; set; }


        SoftwareBitmapSource softwareBitmapSource = new();


        private AcrylicSystemBackdrop acylicBackdrop = new AcrylicSystemBackdrop();
        public AnnoyingWindow()
        {
            ViewModel = new AnnoyingWindowVM();
            this.InitializeComponent();
            this.Maximize();
            this.Backdrop = acylicBackdrop;

            this.IsTitleBarVisible = false;
            this.BringToFront();
            StartCamera();

        }

        async void StartCamera()
        {

            await ShameCamera.StartAsync();
            CurrentFrameImage.Visibility = Visibility.Visible;
            CurrentFrameImage.Source = softwareBitmapSource;
            ShameCamera.CameraHelper.FrameArrived += CameraHelper_FrameArrived;


        }

        private async void CameraHelper_FrameArrived(object? sender, FrameEventArgs e)
        {
            Windows.Media.VideoFrame currentVideoFrame = e.VideoFrame;
            SoftwareBitmap softwareBitmap = currentVideoFrame.SoftwareBitmap;
            var targetSoftwareBitmap = softwareBitmap;

            if (softwareBitmap != null)
            {
                if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 || softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
                    targetSoftwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
                var dispatcher = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();

                await DispatcherQueue.EnqueueAsync(() =>
                {
                    softwareBitmapSource.SetBitmapAsync(targetSoftwareBitmap);
                });



            }
        }


        public void CloseWindow()
        {
            ShameCamera.CameraHelper.CleanUpAsync();

        }

        private void project1Button_Click(object sender, RoutedEventArgs e)
        {
            buttonTest.Text = "button 1 pressed";
        }
        private void project2Button_Click(object sender, RoutedEventArgs e)
        {
            buttonTest.Text = "button 2 pressed";
        }

        private void taskCompletedButton_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
