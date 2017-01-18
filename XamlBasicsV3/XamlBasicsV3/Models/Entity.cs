using SQLite;

namespace XamlBasicsV3.Models
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string StringValue { get; set; }
        public bool Favourite
        {
            get; set;
        }

        public override string ToString()
        {
            return StringValue;
        }

    }

}