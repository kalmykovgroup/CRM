using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using KTSF.Configurations_;
using KTSF.Core.App;
using KTSF.Dto.Company_;
using KTSF.Dto.Object_;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Object = KTSF.Core.App.Object;

namespace KTSF.Components.Windows.CompanyWinComponent
{
    public partial class CompanyComponent : Component
    {
        public ObservableCollection<Company> Companies { get; } = new ObservableCollection<Company>();

        [ObservableProperty] public Company? selectedCompany;
        [ObservableProperty] public Object? selectedObject;
          

        public CompanyComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {

        }

        public override UserControl Initial() => new CompanyComponentUC(this);

        public override async void ComponentLoaded()
        {
            IsLoad = "Загрузка объекта..."; 

            Result<List<Company>, (string? Message, HttpStatusCode)> response = await AppControl.Server.LoadCompanies();

            if (response.IsSuccess) {
                foreach (Company company in response.Value) {
                    Companies.Add(company);
                }
            }
            else
            {
                MessageBox.Show(response.Error.Message);
            }

            IsLoad = null;

        }

        #region Commands

        [RelayCommand]
        public void CompanyClick(object? parameter)
        {
            if(parameter == null) throw new ArgumentNullException(nameof(parameter));

            SelectedCompany = (Company)parameter;
            SelectedObject = null;

        }

        [RelayCommand]
        public async Task ContinueClick() {
            if (SelectedCompany == null || SelectedObject == null) return;

            Result<ObjectSelectResponse, (string? Message, HttpStatusCode)> result = await AppControl.Server.SelectObject(new ObjectSelectRequest(SelectedCompany.Id, SelectedObject.Id));

            if (result.IsSuccess && result.Value.AnonymJwtToken != null) {

                Regedit.SetValue(Configurations.AnonymJwtToken, result.Value.AnonymJwtToken); 

                AppControl.Server.SetAnonymJwtToken(result.Value.AnonymJwtToken);

                AppControl.SignInEmployeeWinComponent.Show();
            }
            else
            {
                MessageBox.Show(result.Error.Message ?? "Server error");
            }
        
        }

        [RelayCommand]
        public void NewCompanyClick() {  
            MessageBox.Show($"Create new Company");
        }

        [RelayCommand]
        public void SettingsClick(object? parameter) {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            Company company = (Company)parameter;

            MessageBox.Show($"Settings Click {company.Name}");
        }
 
        [RelayCommand]
        public void CreateCompanyClick()
        {
        MessageBox.Show("Create Company");

        }
        
        [RelayCommand]
        public void ObjectClick(object? parameter)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));

            Object @object = (Object)parameter;

            SelectedObject = @object;
             

        }

        #endregion
    }
}
