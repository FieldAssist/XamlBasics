using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;
using XamlBasicsV3.Services;
using XamlBasicsV3.ViewModel;

namespace XamlBasicsV3.View
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage()
        {
            vm = new MainPageViewModel();
            BindingContext = vm;
            InitializeComponent();

        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            DisplayAlert("Info", (e.Item as Entity).StringValue, "Ok");
        }



    }
}
