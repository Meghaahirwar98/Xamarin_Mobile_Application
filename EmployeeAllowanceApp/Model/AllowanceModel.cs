using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;

namespace EmployeeAllowanceApp.Model
{

   public class AllowanceModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string allowanceName { get; set; }
        public long EmployeeKey { get; set; }
        public int allowanceId { get; set; }
        public decimal allowanceAmount { get; set; }        
    }
}

