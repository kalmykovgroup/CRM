using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.SignInPageComponent.Components.AuthFormComponent;
using KTSF.ViewModel;
using KTSF.Core.Product_;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using KTSF.Core;

namespace KTSF.Components.CommonComponents.EmployeeSearchComponent
{
    public partial class EmployeeSearchComponent : Component
    {
        public EmployeeSearchComponent(UserControlVM binding, AppControl appControl,
            ObservableCollection<Employee> listEmployees) : base(binding, appControl)
        {
            ListAllEmployees = listEmployees;
        }

        public ObservableCollection<Employee> ListAllEmployees { get; set; }
        public string SearchTag { get; set; } = "";
        
        public override UserControl Initial() => new EmployeeSearchUC(this);
     
        [ObservableProperty] private bool isVisibilityList = false;

        public ObservableCollection<Employee> ListEmployedProduct { get; } = new ObservableCollection<Employee>();

        [ObservableProperty] private string search = "";

        public Action<ObservableCollection<Employee>>? SearchAction;

        [RelayCommand]
        public async Task EmployeeSearchClick()
        {
            
        }

        public async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;

            if (text.Count() > 2)
            {
                ListEmployedProduct.Clear ();

                List<Employee>? newListEmployee =
                    ListAllEmployees.Where(e => e.EmployeeStatus.Name == SearchTag && e.Name.ToLower().Contains(Search.ToLower())).ToList();
                //List<Employee>? newListEmployee = null;

                if (newListEmployee.Count == 0)
                    return;

                foreach (Employee employee in newListEmployee) {
                    ListEmployedProduct.Add (employee);
                }
                
                SearchAction?.Invoke(ListEmployedProduct);
                ListEmployedProduct.Clear ();
                IsVisibilityList = false;
                Search = "";
                
            } else if (text.Length == 0)
            {
                ListEmployedProduct.Clear ();
                SearchAction?.Invoke(ListEmployedProduct);
            }
        }
    }
}
