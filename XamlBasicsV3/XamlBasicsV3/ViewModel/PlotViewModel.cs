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
    public class PlotViewModel : INotifyPropertyChanged
    {
        public PlotModel ThePlotModel { get; set; }
        public PlotViewModel()
        {
            Refresh(0);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private PlotModel CreateColumnPlot()
        {

            var plotModel = new PlotModel { Title = "Column Plot" };

            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 25, Minimum = 0, MinimumPadding = 0, AbsoluteMinimum = 0 });

            var series1 = new ColumnSeries();
            var x = new ColumnItem(6.0);
            series1.Items.Add(new ColumnItem(8.0) { Color = OxyColor.FromRgb(200, 0, 0) });
            series1.Items.Add(new ColumnItem(10.0));
            series1.Items.Add(new ColumnItem(12.0));
            series1.Items.Add(new ColumnItem(16.0) { Color = OxyColor.FromRgb(0, 255, 0) });
            series1.Items.Add(new ColumnItem(18.0));
            series1.Items.Add(new ColumnItem(20.0));
            plotModel.Series.Add(series1);

            return plotModel;
        }
        private PlotModel CreateIntervalSeries()
        {

            var plotModel = new PlotModel { Title = "Bar Plot" };

            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = new[] {
                "Col 1","Col2","Col 3", "Col4"
            }
            });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });

            var series1 = new IntervalBarSeries();
            var x = new ColumnItem(6.0);
            series1.Items.Add(new IntervalBarItem(1, 10) { Color = OxyColor.FromRgb(200, 0, 0), Title = "Series 1" });
            series1.Items.Add(new IntervalBarItem(11, 20) { Color = OxyColor.FromRgb(0, 200, 0), Title = "Series 2" });
            series1.Items.Add(new IntervalBarItem(21, 30) { Color = OxyColor.FromRgb(0, 0, 200), Title = "Series 3" });
            series1.Items.Add(new IntervalBarItem(35, 40) { Color = OxyColor.FromRgb(0, 200, 200), Title = "Series 4" });
            plotModel.Series.Add(series1);

            return plotModel;
        }
        private PlotModel CreateBarSeries()
        {

            var plotModel = new PlotModel { Title = "Bar Plot" };

            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                ItemsSource = new[] {
                "Col 1","Col2","Col 3", "Col4"
            }
            });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Maximum = 25, Minimum = 0, MinimumPadding = 0, AbsoluteMinimum = 0 });

            var series1 = new BarSeries();
            var x = new ColumnItem(6.0);
            series1.Items.Add(new BarItem(10) { Color = OxyColor.FromRgb(200, 0, 0) });
            series1.Items.Add(new BarItem(11) { Color = OxyColor.FromRgb(0, 200, 0) });
            series1.Items.Add(new BarItem(12) { Color = OxyColor.FromRgb(0, 0, 200) });
            series1.Items.Add(new BarItem(15) { Color = OxyColor.FromRgb(0, 200, 200) });
            plotModel.Series.Add(series1);

            return plotModel;
        }
        private PlotModel CreateLinePlot()
        {

            var plotModel = new PlotModel { Title = "Line Plot" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 20, Minimum = 0 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                Color = OxyColor.FromRgb(0, 255, 0),
                LineStyle = LineStyle.DashDashDot,
                LabelFormatString = "{0:.00}"
            };
            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));
            plotModel.Series.Add(series1);

            var series2 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White,
                Color = OxyColor.FromRgb(255, 0, 0),
                LineStyle = LineStyle.Dash
            };
            series2.Points.Add(new DataPoint(0.0, 8.0));
            series2.Points.Add(new DataPoint(1, 7.1));
            series2.Points.Add(new DataPoint(2, 8.2));
            series2.Points.Add(new DataPoint(3, 9.3));
            series2.Points.Add(new DataPoint(4, 12.4));
            series2.Points.Add(new DataPoint(5, 6.2));
            series2.Points.Add(new DataPoint(9.5, 1.9));

            plotModel.Series.Add(series2);

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
            switch (param % 18 + 1)
            {
                case 1:
                    ThePlotModel = OxyPlotExamples.AreaSeriesExamples.DefaultStyle();
                    break;
                case 2:
                    ThePlotModel = OxyPlotExamples.BoxPlotSeriesExamples.BoxPlot();
                    break;
                case 3:
                    ThePlotModel = OxyPlotExamples.ContourSeriesExamples.PeaksWithColors();
                    break;
                case 4:
                    ThePlotModel = OxyPlotExamples.ErrorColumnSeriesExamples.GetErrorColumnSeriesStacked();
                    break;
                case 5:
                    ThePlotModel = OxyPlotExamples.FunctionSeriesExamples.FermatsSpiral();
                    break;
                case 6:
                    ThePlotModel = OxyPlotExamples.HeatMapSeriesExamples.ConfusionMatrix();
                    break;
                case 7:
                    ThePlotModel = OxyPlotExamples.IntervalBarSeriesExamples.IntervalBarSeries();
                    break;
                case 8:
                    ThePlotModel = OxyPlotExamples.LinearBarSeriesExamples.DefaultStyle();
                    break;
                case 9:
                    ThePlotModel = OxyPlotExamples.LineSeriesExamples.CatmullRomInterpolation();
                    break;
                case 10:
                    ThePlotModel = OxyPlotExamples.PieSeriesExamples.InsideLabelColor(); ;
                    break;
                case 11:
                    ThePlotModel = OxyPlotExamples.RectangleBarSeriesExamples.RectangleBarSeries();
                    break;
                case 12:
                    ThePlotModel = OxyPlotExamples.ScatterErrorSeriesExamples.RandomPointsAndError2000();
                    break;
                case 13:
                    ThePlotModel = OxyPlotExamples.ScatterSeriesExamples.ColorMapBlueWhiteRed256();
                    break;
                case 14:
                    ThePlotModel = OxyPlotExamples.StairStepSeriesExamples.StairStepSeriesWithMarkers();
                    break;
                case 15:
                    ThePlotModel = OxyPlotExamples.ThreeColorLineSeriesExamples.ThreeColorLineSeries();
                    break;
                case 16:
                    ThePlotModel = OxyPlotExamples.TornadoBarSeriesExamples.TornadoDiagram2();
                    break;
                case 17:
                    ThePlotModel = OxyPlotExamples.TwoColorAreaSeriesExamples.TwoColorAreaSeriesTwoPolygons();
                    break;
                case 18:
                    ThePlotModel = OxyPlotExamples.TwoColorLineSeriesExamples.TwoColorLineSeries();
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
