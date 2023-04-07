using EmployeeAllowanceApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace EmployeeAllowanceApp.Service
{

    public class UploaderService
    {
        //public bool IsUpload { get; set; }
        public UploaderService()
        {
            Device.StartTimer(TimeSpan.FromSeconds(20), () =>
            { 
            Device.BeginInvokeOnMainThread(() =>
            SaveAllowanceData()
            );
                return true;
            });
        }

        public void SaveAllowanceData()
        {
            List<PostAllowance> AllowanceDetail = App.Database.GetEmpAllowanceData().Result;
            AllowanceService allowanceService = new AllowanceService();

            if(AllowanceDetail != null)
            {
                bool ApiServiceCall = allowanceService.postAllowance(AllowanceDetail);
                if (ApiServiceCall == true)
                {
                    _ = App.Database.DeleteLastDayAllowanceDetail(AllowanceDetail);
                }
                
            }

            
        }
    }
}
