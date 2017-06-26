using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamlBasicsV3.Models.ListView
{
    public class ChildEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
        public bool IsImp { get; set; }
    }

    public class ParentEntity
    {
        public ParentEntity()
        {
            ChildEntity = new List<ListView.ChildEntity>();
        }
        public int Id { get; set; }
        public string Header { get; set; }
        public decimal Score { get; set; }
        public List<ChildEntity> ChildEntity { get; set; }
    }
}
