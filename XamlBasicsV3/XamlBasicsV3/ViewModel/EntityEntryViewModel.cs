using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.ViewModel
{
    public class EntityEntryViewModel : INotifyPropertyChanged
    {
        public string StringValue { get; set; }
        public bool IsFavourite { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public EntityEntryViewModel(string StringVal, bool IsFav)
        {
            IsFavourite = IsFav;
            StringValue = StringVal;
            notifyChanges();
        }
        public void notifyChanges()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("StringValue"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ISFavourite"));
        }

    }
}
