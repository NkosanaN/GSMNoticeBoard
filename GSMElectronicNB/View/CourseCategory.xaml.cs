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
    public partial class CourseCategory : ContentPage
    {
        public CourseCategory()
        {
            InitializeComponent();
        }

        private async void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var check = e.Value;

            switch (check)
            {

                case true :
                    await Navigation.PushModalAsync(new SmsPage());
                break;

                //case "LAW":
                //    await Navigation.PushModalAsync(new SmsPage());
                //    break;

                //case "IT":
                //    await Navigation.PushModalAsync(new SmsPage());
                //    break;

                //case "CSE":
                //    await Navigation.PushModalAsync(new SmsPage());
                //    break;

                default:
                    break;
            }
        }
    }
}