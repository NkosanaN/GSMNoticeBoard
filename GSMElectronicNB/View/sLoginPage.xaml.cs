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
    public partial class sLoginPage : ContentPage
    {
        public sLoginPage()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();
        }

        bool checkInputs()
        {
            bool result = false;

            if (!string.IsNullOrEmpty(EntryName.Text) && !string.IsNullOrEmpty(EntryPassword.Text))
                result = true;


            return result;
        }

        async void BtnLogin(object sender, EventArgs e)
        {

            if (checkInputs())
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "UserDatabase.db");
                var db = new SQLiteConnection(dbPath);
                try
                {
                    var query = db.Table<User>().Where(u => u.UserName.Equals(EntryName.Text) && u.Password.Equals(EntryPassword.Text)).FirstOrDefault();

                    if (query != null)
                    {
                        App.Current.MainPage = new NavigationPage(new CourseCategory());
                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {

                            var r = await DisplayAlert("Failed ", "Record doesn't exist Please check UserName and Password", "Yes", "Cancel");
                            if (r)
                                await Navigation.PushModalAsync(new sLoginPage());
                            else
                            {
                                await Navigation.PushModalAsync(new sLoginPage());
                            }
                        });
                    }
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
                    await DisplayAlert("Failed", " Either Username or Password entry has not been entered ", null, "Ok");
                });
            }

            //await Navigation.PushModalAsync(new CourseCategory());
        }

        async void BtnSignUp(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new RegisterPage());
        }
    }
}