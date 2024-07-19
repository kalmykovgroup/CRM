using CommunityToolkit.Mvvm.ComponentModel; 
using KTSF.Components.CommonComponents.SearchComponent; 
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Components.TabComponents.CompanyComponent;
using KTSF.Components.TabComponents.MoneyComponent;
using KTSF.Components.TabComponents.PurchasesComponent;
using KTSF.Components.TabComponents.SalesComponent;
using KTSF.Components.TabComponents.SettingsComponent;
using KTSF.Components.TabComponents.StaffComponent;
using KTSF.Components.TabComponents.WarehouseComponent;
using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace KTSF.Components.Window.MainMenuComponent
{
    public partial class MainMenuWinComponent : Component
    {
        [ObservableProperty] UserControlVM currentFrame;

        #region Navigate

        public ObservableCollection<TabComponent> TopNavigationBar { get; } = new();
        public ObservableCollection<TabComponent> LeftNavigationBar { get; } = new();

        #endregion

        public MainMenuWinComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl)
        {
            CurrentFrame = new UserControlVM();

            CashiersWorkplaceComponent cashiersWorkplaceComponent = new CashiersWorkplaceComponent(CurrentFrame, appControl);


            LeftNavigationBar.Add(cashiersWorkplaceComponent); 
            LeftNavigationBar.Add(new SalesComponent(CurrentFrame, appControl)); 
            LeftNavigationBar.Add(new PurchasesComponent(CurrentFrame, appControl)); 
            LeftNavigationBar.Add(new WarehouseComponent(CurrentFrame, appControl)); 
            LeftNavigationBar.Add(new MoneyComponent(CurrentFrame, appControl)); 
            LeftNavigationBar.Add(new StaffComponent(CurrentFrame, appControl));
            LeftNavigationBar.Add(new CompanyComponent(CurrentFrame, appControl));
            LeftNavigationBar.Add(new SettingsComponent(CurrentFrame, appControl));

            cashiersWorkplaceComponent.Show();
        }

        public override void Show(object? parametr = null)
        {
            base.Show(); 
            History.Clear();
        } 

        public override UserControl Initial() => new MainMenuWinUC(this);
    }
}
