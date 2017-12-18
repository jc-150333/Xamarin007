using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin007
{
    public class MainPage5 : ContentPage
    {
        public MainPage5()
        {
            var exImage = new ExImage
            {
                HeightRequest = 200,
                Source = ImageSource.FromResource("Xamarin007.tomato.jpg")
            };

            exImage.LongPress += (s, a) =>
            {
                DisplayAlert("", "Long Press", "OK");
            };
            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),

                Children = { exImage }
            };
        }
    }


    public class ExImage : Image
    {
        public event EventHandler LongPress;

        public void OnLongPress()
        {
            if (LongPress != null)
            {
                LongPress(this, new EventArgs());
            }
        }
    }
}