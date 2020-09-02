using GSMElectronicNB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GSMElectronicNB.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestBooks : ContentPage
    {
        Book book = new Book();
        public TestBooks()
        {
            InitializeComponent();
             readR();
        }
        public async void readR() 
        {
            books.ItemsSource = await book.ReadBooks();
        }

    }
}