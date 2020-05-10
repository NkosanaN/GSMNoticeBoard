using GSMElectronicNB.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSMElectronicNB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new sLoginPage();
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
