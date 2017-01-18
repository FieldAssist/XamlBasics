using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBasicsV3.Models;

namespace XamlBasicsV3.Repo
{
    public class DataGenerator
    {
        private static List<string> stringValues = new List<string>
            {
            "Field Assist", "Ritesh", "Flick2Know", "Ravi",
            "India", "Gurugram"
            };
        public static async Task<List<Entity>> getGeneratedEntities()
        {
            var Random = new Random();
            List<Entity> values = new List<Entity>();
            for (int i = 0; i < 5; i++)
            {
                Entity entity = new Entity()
                {
                    Id = i,
                    StringValue = stringValues[Random.Next(stringValues.Count - 1)]
                };
                values.Add(entity);
            }
            return values;
        }
    }

}
