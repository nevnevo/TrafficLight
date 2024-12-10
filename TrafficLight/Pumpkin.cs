using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace TrafficLight
{
    class Pumpkin
    {
        private Image _gif;
        private stance _state = stance.stand;


        public Pumpkin(Image gif, stance state)
        {
            _gif = gif;
            _state = state;
            MatchGifToState();
            Events.OnChange += MatchStanceToLight;
        }
        public enum stance
        {
            stand, jump, run
        }



        public Image MatchGifToState()
        {
            switch (_state)
            {
                case stance.stand:
                    _gif.Source = new BitmapImage(new Uri("ms-appx:///Assets/Gifs/Pumpkinidle.gif"));
                    break;
                case stance.jump:
                    _gif.Source = new BitmapImage(new Uri("ms-appx:///Assets/Gifs/PumpkinJump.gif"));
                    break;
                case stance.run:
                    _gif.Source = new BitmapImage(new Uri("ms-appx:///Assets/Gifs/PumpkinRun.gif"));
                    break;
            }

            return _gif;
        }

        public void MatchStanceToLight(StopLight.light light)
        {
            switch (light)
            {
                case StopLight.light.red:
                    _state = stance.stand;
                    break;
                case StopLight.light.yellow:
                    _state = stance.jump;
                    break;
                case StopLight.light.green:
                    _state = stance.run;
                    break;
            }

            MatchGifToState();

        }


    }
}
