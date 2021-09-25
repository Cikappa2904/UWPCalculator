using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calcolatrice
{
    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class Settings : Page
    {


        ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        public Settings()
        {
            this.InitializeComponent();

            var DefaultTheme = new Windows.UI.ViewManagement.UISettings();
            var uiTheme = DefaultTheme.GetColorValue(Windows.UI.ViewManagement.UIColorType.Background).ToString();



        }


        private void ThemeSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = ThemeSelector.SelectedIndex.ToString();
            switch (selection)
            {
                case "0":
                    if (Window.Current.Content is FrameworkElement frameworkElement)
                    {
                        frameworkElement.RequestedTheme = ElementTheme.Light;
                        localSettings.Values["Theme"] = "Light";
                    }
                    break;
                case "1":
                    if (Window.Current.Content is FrameworkElement frameworkElement1)
                    {
                        frameworkElement1.RequestedTheme = ElementTheme.Dark;
                        localSettings.Values["Theme"] = "Dark";

                    }
                    break;
                case "2":
                    if (Window.Current.Content is FrameworkElement frameworkElement2)
                    {
                        frameworkElement2.RequestedTheme = ElementTheme.Default;
                        localSettings.Values["Theme"] = "SystemDefault";

                    }
                    break;
            }

        }

    }
}
