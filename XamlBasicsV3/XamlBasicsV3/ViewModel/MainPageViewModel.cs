using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;
using XamlBasicsV3.Services;

namespace XamlBasicsV3.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection<EntityGrouping<string, Entity>> TheList { get; set; }
        public MainPageViewModel()
        {
            Init();
        }
        private void Init()
        {
            var listOfEntities = DataGenerator.getGeneratedEntities();
            var sorted = listOfEntities.OrderBy(x => x.StringValue).GroupBy(c => c.StringValue[0]).
                Select(thegroup => new EntityGrouping<string, Entity>(thegroup.Key.ToString(), thegroup));
            TheList = new ObservableCollection<EntityGrouping<string, Entity>>(sorted);
        }


    }
}
