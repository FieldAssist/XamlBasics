using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamlBasicsV3.Data;
using XamlBasicsV3.View;

namespace XamlBasicsV3
{
    public partial class App : Application
    {
        private static EntityDatabase database;
        public static EntityDatabase Database
        {
            get
            {
                if (database == null)
                    database = new EntityDatabase();
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartUpPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
