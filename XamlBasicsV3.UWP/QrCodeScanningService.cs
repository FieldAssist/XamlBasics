using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Interfaces;
using XamlBasicsV3.UWP;

[assembly: Dependency(typeof(QrCodeScanningService))]
namespace XamlBasicsV3.UWP
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner(App.RootFrame.Dispatcher);
            var scanResults = await scanner.Scan();

            return scanResults.Text;
        }
    }
}
