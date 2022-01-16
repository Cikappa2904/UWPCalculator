using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;

using MUXC = Microsoft.UI.Xaml.Controls;
using Windows.UI;


// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace Calcolatrice
{



    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar; //Make titlebar acrylic
            coreTitleBar.ExtendViewIntoTitleBar = true;
 
            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView(); //Make button acrylic
            view.TitleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            view.TitleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;


                if (Window.Current.Content is FrameworkElement frameworkElement)
                {
                    switch (localSettings.Values["Theme"])
                    {
                        case "Light":
                            frameworkElement.RequestedTheme = ElementTheme.Light;
                            break;
                        case "Dark":
                            frameworkElement.RequestedTheme = ElementTheme.Dark;
                            break;
                        case "SystemDefault":
                            frameworkElement.RequestedTheme = ElementTheme.Default;
                            break;
                    }
                }

                if(!IsWindows11())
                {
                    Windows.UI.Xaml.Media.AcrylicBrush myBrush = new Windows.UI.Xaml.Media.AcrylicBrush();
                    myBrush.BackgroundSource = Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop;   //Windows.UI.Xaml.Media.AcrylicBackgroundSource.HostBackdrop
                    var isDark = Application.Current.RequestedTheme == ApplicationTheme.Dark;
                    if (!isDark)
                    {
                        myBrush.TintColor = Color.FromArgb(255, 255, 255, 255);
                    }
                    else
                    {
                        myBrush.TintColor = Color.FromArgb(255, 0, 0, 0);
                    }

                    myBrush.TintOpacity = 0.6;

                    MainFrame.Background = myBrush;
                }




      

            MainFrame.Navigate(typeof(Calculator));
        }

        private void SelectionChanged(MUXC.NavigationView sender, MUXC.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
               MainFrame.Navigate(typeof(Settings));
            }
            else
            {
                MUXC.NavigationViewItem item = args.SelectedItem as MUXC.NavigationViewItem;

                switch (item.Tag.ToString()) //This is a switch with just one case; it's here to be used if I want to add another page
                {
                    case "MainPage":
                        MainFrame.Navigate(typeof(Calculator));
                        break;
                }
            }
        }

        public bool IsWindows11()
        {
            var v = Int64.Parse(Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamilyVersion);
            var build = (v & 0x00000000FFFF0000) >> 16;

            if (build >= 22000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }

}

