using EmployeeAllowanceApp.View_Model;
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
    public partial class AddAllowances : ContentPage
    {
        public AllowanceViewModel _viewModel;
       
        public AddAllowances()
        {
            InitializeComponent();
          BindingContext  = _viewModel = new AllowanceViewModel();
        
        }

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            try
            {
                int total = _viewModel.PresentEmployeeList.Count();
                int select = _viewModel.PresentEmployeeList.Where(emp => emp.IsSelect).Count();
                SelectAll.IsChecked = total == select;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //private bool _allChecked;
        //public bool AllChecked
        //{
        //    get => ;
        //    set
        //    {
        //        if (value != _allChecked)
        //        {
        //            UpdateCompaniesCollection(value);
        //            OnPropertyChanged(nameof(AllChecked));
        //        }
        //    }
        //}

        // public void UpdateCompaniesCollection(bool newValue)
        //{
        //    for (int i = 0; i < _viewModel.PresentEmployeeList.Count; i++)
        //    {
        //        var tempCompany = _viewModel.PresentEmployeeList[i];
        //        tempCompany.IsSelect = newValue;
        //        _viewModel.PresentEmployeeList[i] = tempCompany;
        //    }
        //}
    }
}