using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace Xamarin007
{
    public class MainPage3 : ContentPage
    {
        class Data
        {
            public String Name { get; set; }
            public String Phone { get; set; }
        }
        //s
        public MainPage3()
        {
            var ar = new ObservableCollection<String>();

            foreach (var i in Enumerable.Range(0, 100))
            {
                ar.Add(string.Format("item-{0}", i));
            }

            var listView = new ListView
            {
                ItemsSource = ar,
            };

            const int index = 20;
            ar[index] += " target";

            var buttonStart = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Start",
                Command = new Command(() =>
                {
                    listView.ScrollTo(ar[index], ScrollToPosition.Start, true);
                })
            };

            var buttonEnd = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "End",
                Command = new Command(() =>
                {
                    listView.ScrollTo(ar[index], ScrollToPosition.End, true);
                })
            };

            var buttonCenter = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Center",
                Command = new Command(() =>
                {
                    listView.ScrollTo(ar[index], ScrollToPosition.End, true);
                })
            };

            var buttonMakeVisible = new Button
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Center",
                Command = new Command(() =>
                {
                    listView.ScrollTo(ar[index], ScrollToPosition.End, true);
                })
            };

            Content = new StackLayout
            {
                Padding = new Thickness(0, Device.OnPlatform(20, 0, 0,), 0, 0),
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            buttonStart,
                            buttonEnd,
                            buttonCenter,
                            buttonMakeVisible
                        }
                    },
                    listView
                }
            };
        }
    }
}