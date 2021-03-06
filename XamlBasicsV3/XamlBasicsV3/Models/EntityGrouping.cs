﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.Models
{
    public class EntityGrouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }
        public EntityGrouping(K Key, IEnumerable<T> items)
        {
            this.Key = Key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
