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
    public partial class EditNotificationPage : ContentPage
    {

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public int Id { get; set; }
        public EditNotificationPage(Message model)
        {
            InitializeComponent();


            MessageField.Text = model.Text;
            Id = model.Id;
        }

        private async void Back2List(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NotificationPage());
        }

        private async void BtnUpdate(object sender, EventArgs e)
        {
            try
            {

                var db = new SQLiteConnection(dbPath);
                db.CreateTable<Message>();

                Message message = new Message()
                {
                    Id = Convert.ToInt32(Id),
                    Text = MessageField.Text
                };
                db.Update(message);
                await Navigation.PopModalAsync();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private async void BtnDelete(object sender, EventArgs e)
        {
            try
            {
                var db = new SQLiteConnection(dbPath);
                db.Table<Message>().Delete(x => x.Id == Id);
                await Navigation.PopModalAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}