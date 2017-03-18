using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Xamarin.Forms;
using XamlBasicsV3.Interfaces;
using XamlBasicsV3.ViewModel;

namespace XamlBasicsV3.View
{
    public partial class QRCodeScanView : ContentPage
    {
        private QRCodeScanViewModel vm { get; set; }
        public QRCodeScanView()
        {
            vm = new QRCodeScanViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
        public async void OnClicked(object o, EventArgs e)
        {
            var url = await DependencyService.Get<IQrCodeScanningService>().ScanAsync();
            Device.OpenUri(new Uri(url));
        }
    }
}
