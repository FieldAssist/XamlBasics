using System;
using XamlBasicsV3.Data;
using SQLite;
using System.IO;
using XamlBasicsV3.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConnectionHelper))]
namespace XamlBasicsV3.Droid
{
    public class ConnectionHelper : ISQLite
    {
        public SQLiteConnection GetConnection(string DbName)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            path = Path.Combine(path, DbName);
            var conn = new SQLiteConnection(path);
            return conn;
        }
    }
}