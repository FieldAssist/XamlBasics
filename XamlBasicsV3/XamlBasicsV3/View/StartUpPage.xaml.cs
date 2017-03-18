using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

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
                Navigation.PushAsync(getScanPage());
            }

        }

        private ZXingScannerPage getScanPage()
        {
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                //UseFrontCameraIfAvailable = true,
                TryHarder = true,
                //    PossibleFormats = new List<ZXing.BarcodeFormat>
                //{
                //    ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.EAN_13
                //    }
            };

            //add options and customize page
            var scanPage = new ZXingScannerPage(options)
            {
                DefaultOverlayTopText = "Align the barcode within the frame",
                DefaultOverlayBottomText = "Scan QR Code To Book the Product",
                DefaultOverlayShowFlashButton = false
            };
            scanPage.OnScanResult += (result) =>
            {
                // Stop scanning
                scanPage.IsScanning = false;

                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    await Navigation.PushAsync(new QRCodeScanView(result));
                    //await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
            return scanPage;
        }


    }
}
