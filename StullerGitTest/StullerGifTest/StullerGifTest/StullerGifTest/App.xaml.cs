using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StullerGifTest
{
    public partial class App : Application
    {
        public App ()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new StullerGifTest.MainPage());
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

