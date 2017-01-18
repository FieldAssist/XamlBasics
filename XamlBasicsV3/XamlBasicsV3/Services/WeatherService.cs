using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBasicsV3.Helper;
using XamlBasicsV3.Models.Weather;

namespace XamlBasicsV3.Services
{
    public class WeatherService
    {
        public async Task<WeatherResult> GetWeatherAsync(string url)
        {
            var helper = new RESTHelper<WeatherResult>(url);
            return await helper.getResponse();
        }
    }
}
