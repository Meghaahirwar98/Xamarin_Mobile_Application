using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeAllowanceApp.Model
{
    public class PresentEmployee 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public long EmployeeKey { get; set; }
        public string employeeName { get; set; }
        public bool IsSelect { get; set; }
    }
}
