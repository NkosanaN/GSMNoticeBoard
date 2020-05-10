using GSMElectronicNB.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSMElectronicNB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmsPage : ContentPage
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public SmsPage()
        {
            InitializeComponent();
        }

        private async void BtnSendSms(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<Message>();

            var maxPk = db.Table<Message>().OrderByDescending(c => c.Id).FirstOrDefault();

            Message message = new Message()
            {
                Id = (maxPk == null ? 1 : maxPk.Id + 1),
                Text = EntryMessage.Text
            };
            db.Insert(message);
            //await DisplayAlert(null, message.Text, "Ok");

            bool answer = await DisplayAlert("Question?", "Would you like to send sms", "Yes", "No");

            if (answer) 
            {
                await Navigation.PushModalAsync(new NotificationPage());
            }
            else
            {
                await Navigation.PushModalAsync(new NotificationPage());
            }

        }

        public async void SendSms() 
        {
            //try
            //{
            //    await Sms.ComposeAsync(new SmsMessage(EntryMessage.Text, EntryNumber.Text));
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        } 
    }
}