﻿using System;
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
using ProjectMobieleApps.ViewModels;
using Microsoft.Phone.Maps.Controls;

namespace ProjectMobieleApps
{
    public partial class WeatherPage : PhoneApplicationPage
    {
        private Geolocator locator = null;
        //private double longitude;
        //private double latitude;

        public WeatherPage()
        {
            InitializeComponent();
   
            if (locator == null)
            {
                locator = new Geolocator();
                locator.DesiredAccuracy = PositionAccuracy.High;
            }
            DataContext = App.ViewModel;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            findMe();

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
        }

        async private void  findMe()
        {
            TimeSpan Exceptableage = new TimeSpan(0, 0, 30);
            TimeSpan TimeOut = new TimeSpan(0, 0, 10);
            Geoposition position = await locator.GetGeopositionAsync(Exceptableage, TimeOut);
            

            GeoCoordinate drawCoordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            myLocationMap.Center = drawCoordinate;
            myLocationMap.ZoomLevel = 13;

            App.ViewModel.Longitude = position.Coordinate.Longitude;
            App.ViewModel.Latitude = position.Coordinate.Latitude;

            App.ViewModel.LoadData();

            DataContext = App.ViewModel.Item;
        }

        //public double Longitude
        //{
        //    get
        //    {
        //        return longitude;
        //    }
        //    set
        //    {
        //        longitude = value;
        //    }
        //}

        //public double Latitude
        //{
        //    get
        //    {
        //        return latitude;
        //    }
        //    set
        //    {
        //        latitude = value;
        //    }
        //}
    }
}