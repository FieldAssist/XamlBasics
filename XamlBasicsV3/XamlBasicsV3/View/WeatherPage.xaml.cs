using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamlBasicsV3.ViewModel;

namespace XamlBasicsV3.View
{
    public partial class WeatherPage : ContentPage
    {
        private WeatherPageViewModel vm { get; set; }
        public WeatherPage()
        {
            vm = new WeatherPageViewModel();
            BindingContext = vm;
            InitializeComponent();


        }
        public async void OnClicked(object o, EventArgs e)
        {

            var longitude = double.Parse(lon.Text);
            var latitude = double.Parse(lat.Text);

            var url = string.Format("http://api.geonames.org/findNearByWeatherJSON?lat={0}&lng={1}&username={2}", latitude, longitude, "riteshbxr");
            await vm.GetWeatherAsync(url);
        }
    }
}
