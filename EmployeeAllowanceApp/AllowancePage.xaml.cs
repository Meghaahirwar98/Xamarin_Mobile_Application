using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmployeeAllowanceApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllowancePage : ContentPage
    {
        
        public AllowancePage()
        {
            InitializeComponent();
            TimePicker timePicker = new TimePicker
            {
                Time = new TimeSpan() 
            };
            string hour = DateTime.Now.ToString("HH");
            string minute = DateTime.Now.ToString("mm");
            string second = DateTime.Now.ToString("ss");

            TimePicker.Time = new TimeSpan(Convert.ToInt32(hour), Convert.ToInt32(minute), Convert.ToInt32(second));
        }

        public void UserLogin(object sender, EventArgs e)
        {
            _ = Navigation.PushModalAsync(new AddAllowances());
        }
    }
}