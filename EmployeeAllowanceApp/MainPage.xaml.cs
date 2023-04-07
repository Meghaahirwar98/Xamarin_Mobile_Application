using EmployeeAllowanceApp.View_Model;
using System;
using EmployeeAllowanceApp.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeAllowanceApp
{
    public partial class MainPage : ContentPage
    {
        public AllowanceViewModel _viewModel;
        
        public MainPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new AllowanceViewModel();           
            CancelCommand = new Command(OnCancel);
            //LoginCommand = new Command(UserLogin);
            Text = "ALLOWANCE APP LOGIN";
        }


        //public Command LoginCommand { get; }
        public Command CancelCommand { get; }
        public object Text { get; set; }

        public async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
       
    }
}
    
