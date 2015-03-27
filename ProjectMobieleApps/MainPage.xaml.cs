using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ProjectMobieleApps.Resources;

using Windows.Devices.Geolocation;
using System.Device.Location;

namespace ProjectMobieleApps
{
    public partial class MainPage : PhoneApplicationPage
    {
        private Geolocator locator = null;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();

            if (locator == null)
            {
                locator = new Geolocator();
                locator.DesiredAccuracy = PositionAccuracy.High;

                locator.MovementThreshold = 20; // distance in metres
                locator.PositionChanged += locator_PositionChanged;
                locator.StatusChanged += locator_StatusChanged;
            }
        }

        void locator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            Dispatcher.BeginInvoke(() =>
            {
                updateStatus(args.Status);
            });
        }

        private void updateDisplay(Geoposition position)
        {
            GeoCoordinate drawCoordinate = new GeoCoordinate(position.Coordinate.Latitude, position.Coordinate.Longitude);
            //myLocationMap.Center = drawCoordinate;
            //myLocationMap.ZoomLevel = 13;

            //timeTextBlock.Text = position.Coordinate.Timestamp.ToString();
            //sourceTextBlock.Text = position.Coordinate.PositionSource.ToString();
            //latTextBlock.Text = "Latitude: " + position.Coordinate.Latitude.ToString();
            //longTextBlock.Text = "Longitude: " + position.Coordinate.Longitude.ToString();
        }

        private void ShowWeather_Click(object sender, RoutedEventArgs e)
        {

        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}