using EmployeeAllowanceApp.Model;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeAllowanceApp
{
    public partial class App : Application
    {
        static DatabaseClass database;
        // Create the database connection as a singleton.
        public static DatabaseClass Database
        {
            get
            {
                if (database == null)
                {
                    string data = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AllowanceAppDatabase.db3");
                    database = new DatabaseClass(data);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
