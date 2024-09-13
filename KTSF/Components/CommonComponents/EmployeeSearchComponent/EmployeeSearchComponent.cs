using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.Core.Object;
using KTSF.Core.Object.Product_;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace KTSF.Components.CommonComponents.EmployeeSearchComponent
{
    public partial class EmployeeSearchComponent : Component
    {        
        //public List<Employee> results = [];
        public ObservableCollection<Employee> searchResult = [];

        [ObservableProperty] public string search = "";

        public EmployeeSearchComponent(UserControlVM binding, AppControl appControl, ObservableCollection<Employee> SearchResult) : base(binding, appControl)
        {
            searchResult = SearchResult;
        }

        public override UserControl Initial() => new EmployeeSearchUC(this);


        public async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = ((TextBox)sender).Text;

            if (text.Count() > 2)
            {
                Result<List<Employee>, (string? Error, HttpStatusCode)> result = await AppControl.Server.GetBySurname(text);

                if (result.IsSuccess)
                {
                    searchResult.Clear();

                    foreach (Employee employee in result.Value)
                    {
                        searchResult.Add(employee);
                    }
                }
                else
                {
                    MessageBox.Show(result.Error.Error);
                }
            }
        }


        [RelayCommand]
        public void SearchClick(object? parameter)
        {        
            Search = "";
        }

    }
}
