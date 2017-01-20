using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamlBasicsV3.ViewModel;

namespace XamlBasicsV3.View
{
    public partial class PlotsAndChartView : ContentPage
    {
        private int i = 0;
        public PlotViewModel vm { get; set; }
        public PlotsAndChartView()
        {
            vm = new PlotViewModel();
            BindingContext = vm;
            InitializeComponent();
        }
        public void OnRefresh(object o, EventArgs e)
        {
            vm.Refresh(++i);
        }
    }
}
