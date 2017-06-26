using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;
using XamlBasicsV3.Models.ListView;
using XamlBasicsV3.Services;

namespace XamlBasicsV3.ViewModel
{
    public class ListViewViewModel : INotifyPropertyChanged
    {
        private IEnumerable<ParentEntity> listOfEntities;
        private bool isDatabase;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<EntityGrouping<ParentEntity, ChildEntity>> TheList { get; set; }
        public ListViewViewModel()
        {
            Init();
        }
        private void Init()
        {
                    listOfEntities = DataGenerator.GetGeneratedParents();

            var sorted = listOfEntities.Select(thegroup => new EntityGrouping<ParentEntity, ChildEntity>(thegroup, thegroup.ChildEntity));
            TheList = new ObservableCollection<EntityGrouping<ParentEntity, ChildEntity>>(sorted);
        }

        public void NotifyChanges()
        {
            Init();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TheList"));
        }

    }
}
