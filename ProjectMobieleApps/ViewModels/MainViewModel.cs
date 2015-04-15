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
    class MainViewModel : INotifyPropertyChanged
    {
        WeatherPage wp = new WeatherPage();
        private const string urlString = "http://api.openweathermap.org/data/2.5/weather?lat=50.9&lon=5.4&units=metric&mode=xml";
        private const string filename = "weatherFile.xml";
        

        //private FileIO io = new FileIO();

        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
        }

        public ObservableCollection<ItemViewModel> Items { get; private set; }

        public double Longitude
        {
            get
            {
                return wp.Longitude;
            }

            set
            {
                wp.Longitude = value;
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
