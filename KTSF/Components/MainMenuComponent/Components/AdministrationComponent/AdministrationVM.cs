using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.ActionsPageComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.EquipmentPageComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.SettingOrganizationPageComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.StatisticsPageComponent;
using KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.UsersPageComponents;
using KTSF.Components.MainMenuComponent.Components.CashiersWorkplaceComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent
{
    public partial class AdministrationVM : ObservableObject, IComponent //MainMenuVM -> AdministrationVM
    {
        public AppControl AppControl { get; }

        public AdministrationUC? AdministrationUC { get; private set; }

        public UserControl Build => AdministrationUC != null ? AdministrationUC : Create();

        [ObservableProperty] public UserControl? currentFrame;

        #region Navigate

        public SettingOrganizationPageVM? SettingOrganizationVM { get; private set; }
        public StatisticsPageVM? StatisticsVM { get; private set; }
        public UsersPageVM? UsersVM { get; private set; }
        public ActionsPageVM? ActionsVM { get; private set; }
        public EquipmentPageVM? EquipmentPageVM { get; private set; }

        #endregion 

        public UserControl Create()
        {

            SettingOrganizationVM = new SettingOrganizationPageVM(AppControl);
            StatisticsVM = new StatisticsPageVM(AppControl);
            UsersVM = new UsersPageVM(AppControl);
            ActionsVM = new ActionsPageVM(AppControl);
            EquipmentPageVM = new EquipmentPageVM(AppControl);

            AdministrationUC = new AdministrationUC(this);

            return AdministrationUC;
        }

        public AdministrationVM(AppControl appControl)
        {
            AppControl = appControl;        
        }

        #region Commands
        [RelayCommand]//Организация
        public void OrganizationNav(object? parametr) => CurrentFrame = SettingOrganizationVM?.Build;
         
        [RelayCommand]//Пользователи
        public void UsersNav(object? parametr) => CurrentFrame = UsersVM?.Build;

        [RelayCommand]//События
        public void ActionsNav(object? parametr) => CurrentFrame = ActionsVM?.Build;

        [RelayCommand]//Статистика
        public void StatisticsNav(object? parametr) => CurrentFrame = StatisticsVM?.Build;

        [RelayCommand] //Оборудование
        public void EquipmentPageNav(object? parametr) => CurrentFrame = EquipmentPageVM?.Build;

        #endregion



    }
}
