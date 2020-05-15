using GSMElectronicNB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSMElectronicNB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserDatabase.db");
        public RegisterPage()
        {
            InitializeComponent();
        }

        async void BtnRegister(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<User>();

            User user = new User()
            {
                Password = password.Text,
                UserName = username.Text,
                Email = email.Text
            };
            db.Insert(user);

            Device.BeginInvokeOnMainThread(async () =>
            {

                var r = await DisplayAlert("Successfully ", "User Added", null, "Ok");

                if(!r) 
                {
                    App.Current.MainPage = new NavigationPage(new sLoginPage());
                }
            });

        }
    }
}