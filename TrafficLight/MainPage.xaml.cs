using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TrafficLight
{
    
    public sealed partial class MainPage : Page
    {
        private StopLight TR;
        private bool _IsAuto;
        private Girl girlChar;
        private Pumpkin pumpkinChar;
        
        public MainPage()
        {
            

            this.InitializeComponent();
            TR = new StopLight(StopLight.light.red, greenLight, yellowLight, redLight);
            girlChar = new Girl(GirlImg, Girl.stance.stand);
            pumpkinChar = new Pumpkin(pumpkinImg, Pumpkin.stance.stand);
            TR.Clear();


        }

        private void ManualBtn_Click(object sender, RoutedEventArgs e)
        {
            TR.NextColor();
            


        }

        private void AutoBtn_Click(object sender, RoutedEventArgs e)
        {
            if (_IsAuto)
            
                _IsAuto = false;
                
            
            else
            
                _IsAuto = true;
                
            
            TR.SetIsAuto(_IsAuto);


        }
    }
}
