using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;
using XamlBasicsV3.Repo;

namespace XamlBasicsV3
{
    public partial class MainPage : ContentPage
    {
        public List<Entity> TheList { get; set; }
        public MainPage()
        {
            Init();
            InitializeComponent();
            BindingContext = this;
        }

        private async Task Init()
        {
            TheList = await DataGenerator.getGeneratedEntities();

        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            DisplayAlert("Info", (e.Item as Entity).StringValue, "Ok");
        }
    }
}
