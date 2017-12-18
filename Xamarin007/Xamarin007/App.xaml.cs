using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin007
{
    public partial class App : Application
    {
        //データベースのパスを格納
        public static string dbPath;

        public App(string dbPath)
        {
            //AppのdbPathに引数のパスを設定
            App.dbPath = dbPath;

            InitializeComponent();

            MainPage = new MainPage7();
        }

        protected override void OnStart()
        {
            // Handle when your app startsfg
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
