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
    public partial class NotificationPage : ContentPage
    {

        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "myDB.db3");
        public NotificationPage()
        {
            InitializeComponent();

            GetMessage();
        }

        public void GetMessage() 
        {
            var db = new SQLiteConnection(dbPath);

            ReceivedMessages.ItemsSource = db.Table<Message>().OrderBy(x => x.Text).ToList();
        }

        private async void EditMessage(object sender, ItemTappedEventArgs e)
        {
            var model = e.Item as Message;
            await Navigation.PushModalAsync(new EditNotificationPage(model));
        }
    }
}