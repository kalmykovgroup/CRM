using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
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
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Animation;
using CommunityToolkit.Mvvm.ComponentModel;

namespace KTSF.Components.Windows.MainMenuComponent;

public partial class MainMenuWinComponent : Component {
    [ObservableProperty] UserControlVM currentFrame;


    public event Action RequestClosePane;
    public event Action RequestOpenPane;

    private bool IsPaneOpen { get; set; } = true;

    #region Navigate

    public ObservableCollection<TabComponent> TopNavigationBar { get; } = new ();
    public ObservableCollection<TabComponent> LeftNavigationBar { get; } = new ();

    #endregion

    public MainMenuWinComponent (UserControlVM binding, AppControl appControl) : base (binding, appControl) {
        CurrentFrame = new UserControlVM ();
         


        LeftNavigationBar.Add (new CashiersWorkplaceComponent (CurrentFrame, appControl, "/Img/TabComponents/cashiersWorkplaceIcon.svg"));
        LeftNavigationBar.Add (new SalesComponent (CurrentFrame, appControl, "/Img/TabComponents/SalesIcon.svg"));
        LeftNavigationBar.Add (new PurchasesComponent (CurrentFrame, appControl, "/Img/TabComponents/Purchases.svg"));
        LeftNavigationBar.Add (new WarehouseComponent(CurrentFrame, appControl, "/Img/TabComponents/Warehouse.svg"));
        LeftNavigationBar.Add (new MoneyComponent (CurrentFrame, appControl, "/Img/TabComponents/Money.svg"));
        LeftNavigationBar.Add (new StaffComponent (CurrentFrame, appControl, "/Img/TabComponents/Staff.svg"));
        LeftNavigationBar.Add (new CompanyComponent (CurrentFrame, appControl, "/Img/TabComponents/Company.svg"));
        LeftNavigationBar.Add (new SettingsComponent (CurrentFrame, appControl, "/Img/TabComponents/Settings.svg"));

    }



    public override void Show (object? parametr = null) {
        base.Show ();
        History.Clear ();

        LeftNavigationBar[6].Show();
    }

    public override UserControl Initial () => new MainMenuWinUC (this);
}
