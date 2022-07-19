global using System;
global using System.Collections.Generic;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIEx;

namespace AnnoyMe
{
    public partial class App : Application
    {

        public App()
        {
            this.InitializeComponent();
        }


        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {


            MainWindow = new MainWindow();
            MainWindow.Activate();
            //BaseWindow = new Window();
            //BaseWindow.Activate();
            //AnnoyingWindow = new AnnoyingWindow();
            //AnnoyingWindow.Activate();


        }
        public static Window BaseWindow { get; set; }
        public static MainWindow MainWindow { get; set; }
        public static AnnoyingWindow AnnoyingWindow { get; set; }
    }
}
