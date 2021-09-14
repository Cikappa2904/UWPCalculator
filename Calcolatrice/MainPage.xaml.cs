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
        //Variables declarations
        bool didEqualGetPressed = false, didSignGetPressed = false;
        int lastSignUsed;
        double result, pValore = 0, sValore = 0, tValore = 0;


        public MainPage()
        {
            this.InitializeComponent();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar; //Make titlebar acrylic
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var view = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView(); //Make button acrylic
            view.TitleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            view.TitleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;

            //Setting all the TextBlocks to blank (not doing this in XAML so it's easier to work on the designer)
            primoValore.Text = "";
            risultato.Text = "0";
            segno.Text = "";
            secondoValore.Text = "";
            uguale.Text = "";

            Window.Current.CoreWindow.CharacterReceived += CoreWindow_CharacterReceived;
            

        }

        

        private void CoreWindow_CharacterReceived(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.CharacterReceivedEventArgs args)
        {
            //Make keyboard shortcuts work for stuff that doesn't work as KeyboardAccelerator
            switch (args.KeyCode)
            {
                
                case 8: //Backspace
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
                case 43: //Keyboard Plus Sign 
                    {
                        MathOperation("+");
                        break;
                    }
                case 46: // ',' sign
                    {
                        if (!risultato.Text.Contains(","))
                        {
                            equalClear(",");
                        }
                        break;
                    }
               

            }

                 
            
        } 

        void equalClear(string a)//Function to check if we pressed Equal or a sign, in order to understand if the main TextBlock (risultato) should be cleaned before putting the number
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
        
        void convertingTextBlocks()//Function that converts TextBlock values to "doubles"
        {
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


            primoValore.Text = risultato.Text;
            secondoValore.Text = "";
            uguale.Text = "";
        }

        void CheckingLastUsedSign(string temp)//Function called when pressing a sign that checks if a sign has been pressed before in order to know if the previous operating needs to be executed or not
        {

            
            switch(temp)
            {
                case "+":
                    result = pValore + tValore;
                break;

                case "-":
                    result = pValore - tValore;
                break;

                case "*":
                    result = pValore * tValore;
                break;

                case "/":
                    result = pValore / tValore;
                break;
    
            }
            primoValore.Text = result.ToString();
            //secondoValore.Text = tValore.ToString();
            risultato.Text = result.ToString();
        }

        void MathOperation(string sign)
        {
            convertingTextBlocks();
            if (lastSignUsed != 0)
                CheckingLastUsedSign(sign);


            segno.Text = " " + sign + " ";
            switch (sign)
            {
                case "+":
                    {
                        lastSignUsed = 1;
                        break;
                    }
                case "-":
                    {
                        lastSignUsed = 2;
                        break;
                    }
                case "*":
                    {
                        lastSignUsed = 3;
                        break;
                    }
                case "/":
                    {
                        lastSignUsed = 4;
                        break;
                    }

            }
            
            didSignGetPressed = true;
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
            MathOperation("+");
        }

        private void Button_Click_Minus(object sender, RoutedEventArgs e) //tasto -
        {
            MathOperation("-");
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
            MathOperation("*");
        }

        private void Button_Click_Division(object sender, RoutedEventArgs e) //tasto +
        {
            MathOperation("/");
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e) //deletes everything and reset the main TextBlock (risultato) to 0
        {
            primoValore.Text = "";
            segno.Text = "";
            secondoValore.Text = "";
            risultato.Text = "0";
            uguale.Text = "";
            pValore = 0;
            sValore = 0;
            tValore = 0;
            result = 0;
            lastSignUsed = 0;
        }

        private void Button_Click_Uguale(object sender, RoutedEventArgs e)
        {
            
            if (primoValore.Text != "")
            {
                pValore = double.Parse(primoValore.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }
            if (risultato.Text != "")
            {
                tValore = double.Parse(risultato.Text, System.Globalization.NumberStyles.Any, CultureInfo.CurrentCulture);
            }

            switch (lastSignUsed)
            {
                case 0:
                    {
                        break;
                    }
                case 1: //Caso 1: addizione
                    {
                        primoValore.Text = pValore.ToString();
                        result = pValore + tValore;
                        segno.Text = " + ";
                        secondoValore.Text = tValore.ToString();
                        risultato.Text = result.ToString();
                        uguale.Text = "=";
                        break;
                    }
                case 2: //Caso 2: sottrazione
                    {
                        primoValore.Text = pValore.ToString();
                        result = pValore - tValore;
                        segno.Text = " - ";
                        secondoValore.Text = tValore.ToString();
                        uguale.Text = "=";
                        risultato.Text = result.ToString();
                        break;
                    }
                case 3:
                    {
                        primoValore.Text = pValore.ToString();
                        result = pValore * tValore;
                        segno.Text = " * ";
                        secondoValore.Text = tValore.ToString();
                        uguale.Text = "=";
                        risultato.Text = result.ToString();
                        break;
                    }
                case 4:
                    {
                        primoValore.Text = pValore.ToString();
                        result = pValore / tValore;
                        segno.Text = " / ";
                        secondoValore.Text = tValore.ToString();
                        uguale.Text = "=";
                        risultato.Text = result.ToString();
                        break;
                    }
            }
                     
            
            didEqualGetPressed = true;
            lastSignUsed = 0;

        }

        


    }
}

