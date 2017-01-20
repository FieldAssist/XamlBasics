using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.ViewModel
{
    public class PlotViewModel : INotifyPropertyChanged
    {
        public PlotModel ThePlotModel { get; set; }
        public PlotViewModel()
        {
            Refresh(0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private PlotModel CreateIntervalPlot()
        {

            var plotModel = new PlotModel { Title = "Interval Plot" };

            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 25, Minimum = 0, MinimumPadding = 0, AbsoluteMinimum = 0 });

            var series1 = new ColumnSeries();

            series1.Items.Add(new ColumnItem(6.0));
            series1.Items.Add(new ColumnItem(8.0));
            series1.Items.Add(new ColumnItem(10.0));
            series1.Items.Add(new ColumnItem(12.0));
            series1.Items.Add(new ColumnItem(16.0));
            series1.Items.Add(new ColumnItem(18.0));
            series1.Items.Add(new ColumnItem(20.0));

            plotModel.Series.Add(series1);

            return plotModel;
        }
        private PlotModel CreateLinePlot()
        {

            var plotModel = new PlotModel { Title = "Line Plot" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };
            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;
        }

        private PlotModel CreatePieModel()
        {
            var model = new PlotModel { Title = "Pie Chart" };

            var ps = new PieSeries
            {
                StrokeThickness = 2.0,
                InsideLabelPosition = 0.8,
                AngleSpan = 360,
                StartAngle = 0
            };

            ps.Slices.Add(new PieSlice("Africa", 1030) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Americas", 929) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Asia", 4157));
            ps.Slices.Add(new PieSlice("Europe", 739) { IsExploded = true });
            ps.Slices.Add(new PieSlice("Oceania", 35) { IsExploded = true });

            model.Series.Add(ps);
            return model;
        }
        public void Refresh(int param)
        {
            switch (param % 3)
            {
                case 0:
                    ThePlotModel = CreateIntervalPlot();
                    break;
                case 1:
                    ThePlotModel = CreateLinePlot();
                    break;
                case 2:
                    ThePlotModel = CreatePieModel();
                    break;
            }
            notifyChanges();
        }
        public void notifyChanges()
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ThePlotModel"));
        }
    }
}
