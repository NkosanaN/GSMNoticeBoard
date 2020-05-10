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
        public EditNotificationPage(Message model)
        {
            InitializeComponent();


            MessageField.Text = model.Text;
        }

        private async void Back2List(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NotificationPage());
        }

        private async void BtnUpdate(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Message>();

            Message message = new Message()
            {
                Id = Convert.ToInt32(IdField.Text),
                Text = MessageField.Text
            };
            db.Update(message);
            await Navigation.PopModalAsync();
        }

        private async void BtnDelete(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.Table<Message>().Delete(x => x.Id == Convert.ToInt32(IdField.Text));
            await Navigation.PopModalAsync();
        }
    }
}