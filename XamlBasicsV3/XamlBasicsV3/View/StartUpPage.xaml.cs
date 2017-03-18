using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace XamlBasicsV3.View
{
    public partial class StartUpPage : ContentPage
    {
        public StartUpPage()
        {
            InitializeComponent();
        }

        public void OnClick(object o, EventArgs e)
        {
            Button v = (Button)o;

            if (v.Id == btnStaticList.Id)
            {
                Navigation.PushAsync(new MainPage(false));
            }
            else if (v.Id == btnRESTClientPage.Id)
            {
                Navigation.PushAsync(new WeatherPage());
            }
            else if (v.Id == btnDataBase.Id)
            {
                Navigation.PushAsync(new MainPage(true));
            }
            else if (v.Id == btnGraph.Id)
            {
                Navigation.PushAsync(new PlotsAndChartView());
            }
            else if (v.Id == btnScan.Id)
            {
                Navigation.PushAsync(new QRCodeScanView());
            }

        }
    }
}
