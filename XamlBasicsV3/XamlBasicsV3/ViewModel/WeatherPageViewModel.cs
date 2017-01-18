using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XamlBasicsV3.Models;
using XamlBasicsV3.Models.Weather;
using XamlBasicsV3.Services;

namespace XamlBasicsV3.ViewModel
{
    public class WeatherPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public WeatherObservation observation
        {

            set
            {

                Elevation = value?.elevation;
                Temperature = value?.temperature;
                Humidity = value?.humidity;
                StationName = value?.stationName;

                NotifyPropertyChanged("Elevation");
                NotifyPropertyChanged("Temperature");
                NotifyPropertyChanged("Humidity");
                NotifyPropertyChanged("StationName");
            }
        }
        public long? Elevation
        {
            get; set;
        }
        public long? Temperature
        {
            get; set;
        }
        public long? Humidity
        {
            get; set;
        }
        public string StationName
        {
            get; set;
        }
        public WeatherPageViewModel()
        {
            Init();
        }

        public void Init()
        {
            observation = new WeatherObservation();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task GetWeatherAsync(string url)
        {
            var service = new WeatherService();
            var response = await service.GetWeatherAsync(url);
            setValues(response);

        }

        private void setValues(WeatherResult response)
        {
            if (response.weatherObservation != null)
            {
                observation = response.weatherObservation;
            }
            else
            {
                observation = new WeatherObservation
                {
                    stationName = "NotFound",
                };
            }

            //if (response != null)
            //{
            //    this.Elevation = response.weatherObservation.elevation;
            //    this.Humidity = response.weatherObservation.humidity;
            //    this.Temperature = response.weatherObservation.temperature;
            //    this.StationName = response.weatherObservation.stationName;
            //}
            //else
            //{
            //    Elevation = default(long);
            //    Humidity = default(long);
            //    Temperature = default(long);
            //    StationName = default(string);
            //}
        }
    }
}
