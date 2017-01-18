using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Grouping<string, Entity>> TheList { get; set; }
        public MainPage()
        {
            Init();
            InitializeComponent();
            BindingContext = TheList;
        }

        private void Init()
        {
            var listOfEntities = DataGenerator.getGeneratedEntities();
            var sorted = listOfEntities.OrderBy(x => x.StringValue).GroupBy(c => c.StringValue[0]).
                Select(thegroup => new Grouping<string, Entity>(thegroup.Key.ToString(), thegroup));
            TheList = new ObservableCollection<Grouping<string, Entity>>(sorted);
        }

        public void OnItemTapped(object o, ItemTappedEventArgs e)
        {
            DisplayAlert("Info", (e.Item as Entity).StringValue, "Ok");
        }
    }
}
