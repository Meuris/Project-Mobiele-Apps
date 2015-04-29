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

namespace ProjectMobieleApps.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private string city;
        private string country;
        private string temperature;
        private string humidity;
        private string windSpeed;
        private string windDirection;
        private string clouds;

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                if(value != city)
                {
                    city = value;
                    NotifyPropertyChanged("City");
                }
            }
        }

        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if(value != country)
                {
                    country = value;
                    NotifyPropertyChanged("Country");
                }
            }
        }

        public string Temperature
        {
            get
            {
                return temperature;
            }
            set
            {
                if(value != temperature)
                {
                    temperature = value;
                    NotifyPropertyChanged("Temperature");
                }
            }
        }

        public string Humidity
        {
            get
            {
                return humidity;
            }
            set
            {
                if(value != humidity)
                {
                    humidity = value;
                    NotifyPropertyChanged("Humidity");
                }
            }
        }

        public string WindSpeed
        {
            get
            {
                return windSpeed;
            }
            set
            {
                if(value != windSpeed)
                {
                    windSpeed = value;
                    NotifyPropertyChanged("WindSpeed");
                }
            }
        }

        public string WindDirection
        {
            get
            {
                return windDirection;
            }
            set
            {
                if(value != windDirection)
                {
                    windDirection = value;
                    NotifyPropertyChanged("WindDirection");
                }
            }
        }

        public string Clouds
        {
            get
            {
                return clouds;
            }
            set
            {
                if(value != clouds)
                {
                    clouds = value;
                    NotifyPropertyChanged("Clouds");
                }
            }
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
