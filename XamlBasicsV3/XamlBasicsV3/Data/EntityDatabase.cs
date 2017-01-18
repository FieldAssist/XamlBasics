using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamlBasicsV3.Models;

namespace XamlBasicsV3.Data
{
    public class EntityDatabase
    {
        private SQLiteConnection database;
        static object locker = new object();
        public EntityDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Entity>();
        }

        public long SaveEntity(Entity entity)
        {
            lock (locker)
            {
                if (entity.Id != 0)
                {
                    database.Update(entity);
                    return entity.Id;
                }
                else
                {
                    return database.Insert(entity);
                }
            }
        }
        public IEnumerable<Entity> GetEntities()
        {
            lock (locker)
            {
                return database.Table<Entity>().Select(x => x).ToList();
            }
        }
        public Entity getEntity(long Id)
        {
            lock (locker)
            {
                return database.Table<Entity>().Where(e => e.Id == Id).FirstOrDefault(); ;
            }
        }
    }
}
