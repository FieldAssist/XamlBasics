using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;
using XamlBasicsV3.Services;

namespace XamlBasicsV3.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private IEnumerable<Entity> listOfEntities;
        private bool isDatabase;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<EntityGrouping<string, Entity>> TheList { get; set; }
        public MainPageViewModel(bool isDatabase)
        {
            this.isDatabase = isDatabase;
            Init(isDatabase);
        }
        private void Init(bool isDatabase)
        {
            switch (isDatabase)
            {
                case false:
                    listOfEntities = DataGenerator.getGeneratedEntities();
                    break;
                case true:
                    listOfEntities = App.Database.GetEntities();
                    break;
            }
            var sorted = listOfEntities.OrderBy(x => x.StringValue).GroupBy(c => c.StringValue[0]).
                Select(thegroup => new EntityGrouping<string, Entity>(thegroup.Key.ToString(), thegroup));
            TheList = new ObservableCollection<EntityGrouping<string, Entity>>(sorted);
        }

        public void notifyChanges()
        {
            Init(isDatabase);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TheList"));
        }

    }
}
