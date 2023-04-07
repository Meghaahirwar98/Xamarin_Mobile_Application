using EmployeeAllowanceApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EmployeeAllowanceApp.Service
{
    public class AllowanceService
    {
        public string URl = ("http://192.168.4.19/MeghaAPI/api/EmployeeAllowanceDetails");
        public IEnumerable<AllowanceModel> AllowanceNameList()
        {
            HttpClient client = new HttpClient();
            var url = new Uri(URl + "/allAllowance");
            var response = client.GetStringAsync(url);
            var ListAllowance = JsonConvert.DeserializeObject<List<AllowanceModel>>(response.Result);
            return ListAllowance;         
            
        }

        public IEnumerable<PresentEmployee> PresentEmployeeDetails()
        {
            HttpClient client = new HttpClient();
            var url = new Uri(URl + "/allTodayAttendance");
            var response = client.GetStringAsync(url);
            var PresentEmployeeList = JsonConvert.DeserializeObject<List<PresentEmployee>>(response.Result);
            return PresentEmployeeList;
        }

        //public IEnumerable<AllowanceModel> GetCredentials()
        //{
        //    HttpClient client = new HttpClient();
        //    var url = new Uri(URl + "/allTodayAttendance");
        //    var response = client.GetStringAsync(url);
        //    var PresentEmployeeList = JsonConvert.DeserializeObject<List<AllowanceModel>>(response.Result);
        //    return PresentEmployeeList;
        //}

        public bool postAllowance(List<PostAllowance> addEmpAllowance)
        {
            string json = JsonConvert.SerializeObject(addEmpAllowance);
            HttpContent httpContent = new StringContent(json);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpClient client = new HttpClient();
            var url = client.PostAsync(URl + "/postEmployeeAllowance", httpContent);
            return url.Result.IsSuccessStatusCode;
           
        }
    }
}
