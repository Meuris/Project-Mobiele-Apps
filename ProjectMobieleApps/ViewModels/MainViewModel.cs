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
using System.Linq;

namespace ProjectMobieleApps.ViewModels
{
    class MainViewModel 
    {
        private const string urlString = "http://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&mode=xml";
        private const string filename = "weatherFile.xml";

        private FileIO io = new FileIO();

        //https://www.youtube.com/watch?v=zm2tOtr8ReM
    }
}
