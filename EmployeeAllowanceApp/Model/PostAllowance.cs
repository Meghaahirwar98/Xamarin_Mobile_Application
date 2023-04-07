using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeAllowanceApp.Model
{
    public class PostAllowance : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        [PrimaryKey, AutoIncrement]
        public int SerialNo { get; set; }
        public int allowanceId { get; set; }
        public decimal allowanceAmount { get; set; }
        public long EmployeeKey { get; set; }
        public DateTime clockDate { get; set; }
        //public bool IsUpload { get; set; }
        
        //public string ClockDate { get; set; }
        //public int AllowanceAmount { get; set; }
        //public int AllowanceID { get; set; }
    }
}
