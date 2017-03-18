using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Xamarin.Forms;
using XamlBasicsV3.ViewModel;
using ZXing;

namespace XamlBasicsV3.View
{
    public partial class QRCodeScanView : ContentPage
    {

        private QRCodeScanViewModel vm { get; set; }

        public QRCodeScanView(Result result)
        {
            vm = new QRCodeScanViewModel();
            BindingContext = vm;
            vm.QRCodeValue = result.Text;
            InitializeComponent();
        }
    }
}
