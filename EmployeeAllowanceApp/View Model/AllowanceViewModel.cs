using EmployeeAllowanceApp.Model;
using EmployeeAllowanceApp.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EmployeeAllowanceApp.View_Model
{
    public class AllowanceViewModel : INotifyPropertyChanged

    {

        public event PropertyChangedEventHandler PropertyChanged;
        public List<AllowanceModel> AllowanceNameList { get; set; }
        public List<PresentEmployee> PresentEmployeeList { get; set; }
        public AllowanceModel SelectedAllowance { get; set; }
        public PostAllowance AllowanceId { get; set; }
        public decimal Amount { get; set; }
        public Command SaveCommand { get; }
        public string Title { get; }
        public object Container { get; set; }
        public object Tap { get; set; }
        public Command LoginCommand { get; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public AllowanceViewModel()
        {
            AllowanceService allowanceService = new AllowanceService();
            AllowanceNameList = (List<AllowanceModel>)allowanceService.AllowanceNameList();
            PresentEmployeeList = (List<PresentEmployee>)allowanceService.PresentEmployeeDetails();
            //GetEmpLoginCredentials = (List<AllowanceModel>)allowanceService.GetCredentials();
            SaveCommand = new Command(SaveAllowanceData);
            LoginCommand = new Command(LoginClick);
            Title = "ALLOWANCE APP";
        }

        public void LoginClick()
        {
            if (string.IsNullOrEmpty(UserId) && string.IsNullOrEmpty(Password))
            {
                App.Current.MainPage.DisplayAlert("Empty Feilds", "Please enter your valid UserId and password", "Ok");
            }
            else
            {
                if (UserId == null && Password != null)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter your UserId", " Ok");
                }
                else if (UserId != null && Password == null)
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter your password", " Ok");
                }
                else if (UserId == "M" && Password != "123")
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter your valid password", " Ok");
                }
                else if (UserId != "M" && Password == "123")
                {
                    App.Current.MainPage.DisplayAlert("Alert", "Please enter your valid user Id", " Ok");
                }

                else
                {
                    if (UserId == "M" && Password == "123")
                    {
                        var a = App.Database.GetEmpAllowanceData().Result;
                        App.Current.MainPage.Navigation.PushModalAsync(new AllowancePage());
                    }
                }
            }
        }

        public async void SaveAllowanceData()
        {
            
            List<PostAllowance> ListAllowance = new List<PostAllowance>();
            //var allowanceService = new AllowanceService();
            
            foreach (var emp in PresentEmployeeList)
            {
                if (emp.IsSelect && Amount > 0)
                {
                    PostAllowance EmpAllowance = new PostAllowance
                    {
                        EmployeeKey = emp.EmployeeKey,
                        allowanceId = SelectedAllowance.allowanceId,
                        clockDate = DateTime.Now, 
                        allowanceAmount = Amount,
                        
                    };
                    ListAllowance.Add(EmpAllowance);
                }  
            }           
            if (ListAllowance.Count > 0)
            {                                 
                App.Database.SaveEmpAllowanceData(ListAllowance);
                _ = new UploaderService();
                App.Current.MainPage.DisplayAlert("Success", "Records saved successfully", "Ok");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Alert", "Fill the empty field", "Ok");
            }
        }
    }
}
