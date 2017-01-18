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
            get
            {
                return Id % 2 == 1 ? true : false;
            }

        }

        public override string ToString()
        {
            return StringValue;
        }

    }

}