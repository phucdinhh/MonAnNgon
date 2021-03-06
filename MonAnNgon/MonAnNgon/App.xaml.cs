using MonAnNgon.Models;
using MonAnNgon.Services;
using MonAnNgon.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MonAnNgon
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Database db = new Database();
            db.CreateDatabase();
            DependencyService.Register<AppDataStore>();
            MainPage = new AppShell();
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
