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

        bool checkInputs()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password.Text) && !string.IsNullOrEmpty(username.Text))
                result = true;

            return result;
        }

        async void BtnRegister(object sender, EventArgs e)
        {
            if (checkInputs())
            {
                var db = new SQLiteConnection(dbPath);
                db.CreateTable<User>();
                try
                {

                    User user = new User()
                    {
                        Password = password.Text,
                        UserName = username.Text,
                        //Email = email.Text
                    };
                    db.Insert(user);

                    Device.BeginInvokeOnMainThread(async () =>
                    {

                        var r = await DisplayAlert("Successfully ", "User Added", null, "Ok");

                        if (!r)
                        {
                            App.Current.MainPage = new NavigationPage(new sLoginPage());
                        }
                    });
                }
                catch (Exception ex)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await DisplayAlert("Failed", "Please verify Username or Password, Or Sign Up", null, "Ok");
                    });

                } 
            }
            else
            {

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await DisplayAlert("Failed", " Either Username , Password or Email entry has not been entered ", null, "Ok");
                });
            }

        }
    }
}