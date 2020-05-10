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
    public partial class sLoginPage : ContentPage
    {
        public sLoginPage()
        {
            InitializeComponent();
        }

        private async void BtnLogin(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new CourseCategory());
        }
    }
}