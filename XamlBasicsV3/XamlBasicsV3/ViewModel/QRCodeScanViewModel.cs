using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamlBasicsV3.ViewModel
{
    public class QRCodeScanViewModel : INotifyPropertyChanged
    {
        public string QRCodeValue
        {
            get; set;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void notifyChanges()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("QRCodeValue"));
        }
    }
}
