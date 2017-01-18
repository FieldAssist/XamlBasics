namespace XamlBasicsV3.Models
{
    public class Entity
    {
        public long Id { get; set; }
        public string StringValue { get; set; }

        public override string ToString()
        {
            return StringValue;
        }

    }

}