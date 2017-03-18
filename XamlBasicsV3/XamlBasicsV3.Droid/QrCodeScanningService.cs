using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBasicsV3.Interfaces;

[assembly: Dependency(typeof(QrCodeScanningService))]
namespace XamlBasicsV3.Droid
{
    public class QrCodeScanningService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner(Application.Context);
            var scanResults = await scanner.Scan();

            return scanResults.Text;
        }
    }
}
