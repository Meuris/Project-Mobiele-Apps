using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using Windows.Devices.Geolocation;
using System.Device.Location;

namespace ProjectMobieleApps
{
    public partial class WeatherPage : PhoneApplicationPage
    {
        private Geolocator locator = null;

        public WeatherPage()
        {
            InitializeComponent();

            if (locator == null)
            {
                locator = new Geolocator();
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Display();
            findMe();
            base.OnNavigatedTo(e);
        }

        private void Display()
        {
            sourceTextBlock.Text = "Berekenen";
            timeTextBlock.Text = "Berekenen";
            longTextBlock.Text = "Berekenen";
            latTextBlock.Text = "Berekenen";
        }

        async private void  findMe()
        {
            Geoposition position = await locator.GetGeopositionAsync();

            sourceTextBlock.Text = position.Coordinate.PositionSource.ToString();
            timeTextBlock.Text = position.Coordinate.Timestamp.ToString();
            longTextBlock.Text = position.Coordinate.Longitude.ToString();
            latTextBlock.Text = position.Coordinate.Latitude.ToString();
        }
    }
}