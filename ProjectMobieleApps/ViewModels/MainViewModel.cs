using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using System.Xml.Linq;
using Microsoft.Phone.Net.NetworkInformation;
using Microsoft.Phone.Shell;
using PhoneClassLibrary1;
using System.Globalization;

namespace ProjectMobieleApps.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private double longitude;
        private double latitude;
        ItemViewModel item = new ItemViewModel();
        private string urlString = "http://api.openweathermap.org/data/2.5/weather?lat="; 
        private const string filename = "weatherFile.xml";
        private NumberFormatInfo nfi = new NumberFormatInfo();
              

        private FileIO io = new FileIO();

        public MainViewModel()
        {
            //this.Items = new ObservableCollection<ItemViewModel>();
            nfi.NumberDecimalSeparator = ".";
        }

        //public ObservableCollection<ItemViewModel> Items { get; private set; }

        public double Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude");
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
                NotifyPropertyChanged("Latitude");
            }
        }

        public ItemViewModel Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
            }
        }

        public void LoadData()
        {
            if (DeviceNetworkInformation.IsNetworkAvailable)
            {
                DownloadFeed();
            }
            else
            {
                ReadFeed();
            }
        }

        public void DownloadFeed()
        {
            //this.Items.Clear();

            if(DeviceNetworkInformation.IsNetworkAvailable)
            {
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                client.DownloadStringAsync(new Uri(urlString = urlString + Convert.ToString(App.ViewModel.Latitude,nfi) + "&lon=" + Convert.ToString(App.ViewModel.Longitude,nfi) + "&units=metric&mode=xml"));
            }            
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string weatherData;

            if(e.Error != null)
                return;
            weatherData = e.Result;

            io.SaveDataToFile(filename, weatherData);

            ParseFeed(weatherData);
        }

        public void ReadFeed()
        {
            string weatherData;

            if(io.LoadTextFromFile(filename, out weatherData))
            {
                ParseFeed(weatherData);
            }
        }

        public void ParseFeed(string weatherData)
        {
            XDocument data = XDocument.Parse(weatherData);

            item.Country = data.Element("current").Element("city").Element("country").Value;
            item.City = data.Element("current").Element("city").Attribute("name").Value;
            item.Temperature = data.Element("current").Element("temperature").Attribute("value").Value + "°C";
            item.Humidity = data.Element("current").Element("humidity").Attribute("value").Value + data.Element("current").Element("humidity").Attribute("unit").Value;
            item.WindSpeed = data.Element("current").Element("wind").Element("speed").Attribute("name").Value;
            item.WindDirection = data.Element("current").Element("wind").Element("direction").Attribute("name").Value;
            item.Clouds = data.Element("current").Element("clouds").Attribute("name").Value;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}


