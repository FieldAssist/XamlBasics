using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.Models.Weather
{
    public partial class WeatherObservation
    {
        public string weatherCondition { get; set; }
        public long elevation { get; set; }
        public long lng { get; set; }
        public long temperature { get; set; }
        public long dewPoint { get; set; }
        public long windSpeed { get; set; }
        public long humidity { get; set; }
        public string stationName { get; set; }
    }
}
