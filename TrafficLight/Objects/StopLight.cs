using System;
using System.Collections.Generic;
using System.Windows;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
using System.Timers;
using Windows.UI.Xaml;

namespace TrafficLight
{

    public class StopLight
    {
        private light _color;

        private Ellipse _GreenLight;
        private Ellipse _YellowLight;
        private Ellipse _RedLight;
        private bool _IsAuto;
        private DispatcherTimer _autoTimer;
        

        public StopLight(light color, Ellipse GreenLight, Ellipse YellowLight, Ellipse RedLight)
        {

            _color = color;
            _GreenLight = GreenLight;
            _RedLight = RedLight;
            _YellowLight = YellowLight;


            _autoTimer = new DispatcherTimer();//build timer object
            _autoTimer.Stop();//Stopping the timer
            _autoTimer.Interval = TimeSpan.FromSeconds(1);//setting the timer interval
            _autoTimer.Tick += _autoTimer_Tick;
            
        }

        private void _autoTimer_Tick(object sender, object e)
        {
            NextColor();
        }
        public enum light
        {
            red, green, yellow

        }

        internal light GetLight()
        {
            return _color;
        }

        public void SetIsAuto(bool isAuto)
        {
            _IsAuto = isAuto;
            if (_IsAuto)
                _autoTimer.Start();
            else
            {
                _autoTimer.Stop(); 
            }

        }
        
        
        public void NextColor()
        {
            Clear();
            
            switch (_color)
            {
                case (light.red):
                    _color = light.yellow;
                    _YellowLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 215, 0));
                    break;
                case (light.yellow):
                    _GreenLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 50, 205, 50));
                    _color = light.green;

                    break;
                case (light.green):
                    _color = light.red;
                    _RedLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(255, 255, 0, 0));
                    break;
            }

        }

        public void Clear()
        {
            _GreenLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(125, 128, 128, 128));
            _YellowLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(125, 128, 128, 128));
            _RedLight.Fill = new SolidColorBrush(Windows.UI.Color.FromArgb(125, 128, 128, 128));
        }

    }
}
