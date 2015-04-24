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
        private double longitude;
        private double latitude;

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
            //sourceTextBlock.Text = "Berekenen";
            //timeTextBlock.Text = "Berekenen";
            //longTextBlock.Text = "Berekenen";
            //latTextBlock.Text = "Berekenen";
        }

        async private void  findMe()
        {
            Geoposition position = await locator.GetGeopositionAsync();

            App.ViewModel.Longitude = position.Coordinate.Longitude;
            App.ViewModel.Latitude = position.Coordinate.Latitude;

            App.ViewModel.LoadData();

            //datacontext = App.Viewmodel.Item;

            //countryTextBlock.Text = App.ViewModel.;
            //sourceTextBlock.Text = position.Coordinate.PositionSource.ToString();
            //timeTextBlock.Text = position.Coordinate.Timestamp.ToString();
            //longTextBlock.Text = Convert.ToString(longitude);
            //latTextBlock.Text = position.Coordinate.Latitude.ToString();
        }

        public double Longitude
        {
            get
            {
                return longitude;
            }
            set
            {
                longitude = value;
            }
        }

        public double Latitude
        {
            get
            {
                return latitude;
            }
            set
            {
                latitude = value;
            }
        }
    }
}