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


// Il modello di elemento Pagina vuota è documentato all'indirizzo https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x410

namespace Calcolatrice
{



    /// <summary>
    /// Pagina vuota che può essere usata autonomamente oppure per l'esplorazione all'interno di un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        bool didEqualGetPressed = false, didSignGetPressed = false;
        int lastSignUsed;
        double result, pValore = 0, sValore = 0, tValore = 0;


        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar; //make titlebar acrylic
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView(); //make button acrylic
            view.TitleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            view.TitleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;

            primoValore.Text = "";
            risultato.Text = "0";
            segno.Text = "";
            secondoValore.Text = "";
            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
            

        }

        

        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {

            switch (args.KeyCode)
            {
                
                case 8:
                    {
                        if (risultato.Text.Length > 1)
                        {
                            risultato.Text = risultato.Text.Remove(risultato.Text.Length - 1);
                        }
                        else if (risultato.Text.Length == 1)
                        {
                            risultato.Text = risultato.Text.Replace(risultato.Text, "0");
                        }
                        break;
                    }
                    
            }

                 
            
        } 

        void equalClear(string a) //Funzione che controlla se è stato premuto il tasto uguale o un segno, in modo da capire se la prossima volta che si digita un numero bisogna cancellare la textbox
        {
            if (risultato.Text.Length < 15)
            {
                if (a != "0" && a != "," && risultato.Text == "0" ) 
                {
                    risultato.Text = a;
                }
                else if (!didEqualGetPressed && !didSignGetPressed)
                {
                    risultato.Text = risultato.Text + a;
                }
                else
                {
                    risultato.Text = "";
                    risultato.Text = a;
                    didEqualGetPressed = false;
                    didSignGetPressed = false;
                }
            }
            else
            {
                if (didSignGetPressed)
                {
                    risultato.Text = "";
                    risultato.Text = a;
                    didSignGetPressed = false;
                }    
            }

           

            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            equalClear("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            equalClear("2");
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            equalClear("3");
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            equalClear("4");
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            equalClear("5");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            equalClear("6");
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            equalClear("7");
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            equalClear("8");
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            equalClear("9");
        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if(risultato.Text != "0")
            {
                equalClear("0");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) //tasto +
        {
           

            primoValore.Text = risultato.Text;
           
            if (primoValore.Text != "")
            {
                pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                pValore = 0;
            }

            if (secondoValore.Text != "")
            {
                sValore = double.Parse(secondoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                sValore = 0;
            }

            if (risultato.Text != "")
            {
                tValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                tValore = 0;
            }

            if (lastSignUsed != 0)
            {
                result = pValore + sValore + tValore;
                risultato.Text = result.ToString();
                
            }
                segno.Text = "+";
                lastSignUsed = 1;
                didSignGetPressed = true;
            
            
            

            
            
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e) //tasto -
        {
            primoValore.Text = risultato.Text;

            if (primoValore.Text != "")
            {
                pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                pValore = 0;
            }

            if (secondoValore.Text != "")
            {
                sValore = double.Parse(secondoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                sValore = 0;
            }

            if (risultato.Text != "")
            {
                tValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                tValore = 0;
            }

            if (lastSignUsed != 0)
            {
                result = pValore - sValore - tValore;
                risultato.Text = result.ToString();
                segno.Text = "-";
            }

            lastSignUsed = 2;
            didSignGetPressed = true;
        }

        private void Button_Click_Dot(object sender, RoutedEventArgs e)
        {
            if (!risultato.Text.Contains(","))
            {
                equalClear(",");
            }
            
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e) //tasto +
        {
            primoValore.Text = risultato.Text;

            if (primoValore.Text != "")
            {
                pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                pValore = 0;
            }

            if (secondoValore.Text != "")
            {
                sValore = double.Parse(secondoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                sValore = 0;
            }

            if (risultato.Text != "")
            {
                tValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                tValore = 0;
            }

            if (lastSignUsed != 0)
            {
                result = pValore * sValore * tValore;
                risultato.Text = result.ToString();
                segno.Text = "*";
            }

            lastSignUsed = 3;
            didSignGetPressed = true;
        }

        


        private void Button_Click_Division(object sender, RoutedEventArgs e) //tasto +
        {
            primoValore.Text = risultato.Text;

            if (primoValore.Text != "")
            {
                pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                pValore = 0;
            }

            if (secondoValore.Text != "")
            {
                sValore = double.Parse(secondoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                sValore = 0;
            }

            if (risultato.Text != "")
            {
                tValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            else
            {
                tValore = 0;
            }

            if (lastSignUsed != 0)
            {
                result = pValore / sValore / tValore;
                risultato.Text = result.ToString();
                segno.Text = "/";
            }

            lastSignUsed = 4;
            didSignGetPressed = true;
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e) //deletes everything and reset the main TextBlock (risultato) to 0
        {
            primoValore.Text = "";
            segno.Text = "";
            secondoValore.Text = "";
            risultato.Text = "0";
        }

        


        private void Button_Click_Uguale(object sender, RoutedEventArgs e)
        {
            pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            sValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            switch (lastSignUsed)
            {
                case 1: //Caso 1: addizione
                    {
                        result = pValore + sValore;
                        primoValore.Text = pValore.ToString();
                        segno.Text = "+";
                        secondoValore.Text = sValore.ToString();
                        break;
                    }
                case 2: //Caso 2: sottrazione
                    {
                        result = pValore - sValore;
                        primoValore.Text = pValore.ToString();
                        segno.Text = " - ";
                        secondoValore.Text = sValore.ToString();
                        break;
                    }
                case 3:
                    {
                        result = pValore * sValore;
                        primoValore.Text = pValore.ToString();
                        segno.Text = " * ";
                        secondoValore.Text = sValore.ToString();
                        break;
                    }
                case 4:
                    {
                        result = pValore / sValore;
                        primoValore.Text = pValore.ToString();
                        segno.Text = " / ";
                        secondoValore.Text = sValore.ToString();
                        break;
                    }
            }
           
            risultato.Text = result.ToString();
            didEqualGetPressed = true;
            lastSignUsed = 0;

        }

        


    }
}

