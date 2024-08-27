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
        public EmployeeSearchComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl) {           
        }
        
        public static readonly DependencyProperty ParentTagProperty =
            DependencyProperty.Register("ParentTag", typeof(object), typeof(EmployeeSearchComponent), new PropertyMetadata(null));

        public object ParentTag
        {
            get => GetValue(ParentTagProperty);
            set => SetValue(ParentTagProperty, value);
        }
        
        public override UserControl Initial() => new EmployeeSearchUC(this);

     
        [ObservableProperty] public bool isVisibilityList = false;

        public ObservableCollection<Employee> ListEmployedProduct { get; } = new ObservableCollection<Employee>();

        [ObservableProperty] public string search = "";

        public Employee SelectedProduct = new Employee();

        public Action<Employee>? SearchAction;

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
                
                List<Employee>? newListEmployee = await AppControl.Server.EmployeeSearchProducts(text);

                if (newListEmployee == null)
                    return;
                else
                    IsVisibilityList = true;

                foreach (Employee employee in newListEmployee) {
                    ListEmployedProduct.Add (employee);
                }
            }
        }

        [RelayCommand]
        public void EmployeeClick(object? parameter)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(nameof(parameter));
            }

            SearchAction?.Invoke((Employee)parameter);
            ListEmployedProduct.Clear ();
            IsVisibilityList = false;
            Search = "";
        }

    }
}
