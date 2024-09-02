using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Components.TabComponents.CompanyComponent;
using KTSF.Components.TabComponents.MoneyComponent;
using KTSF.Components.TabComponents.PurchasesComponent;
using KTSF.Components.TabComponents.SalesComponent;
using KTSF.Components.TabComponents.SettingsComponent;
using KTSF.Components.TabComponents.StaffComponent;
using KTSF.Components.TabComponents.WarehouseComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Languages
{


    public interface ILanguage
    {   
        public ITranslationSearchComponent ITranslationSearchComponent { get; }
        public ITranslationCashiersWorkplaceComponent ITranslationCashiersWorkplaceComponent { get; }
        public ITranslationCompanyComponent ITranslationCompanyComponent { get; }
        public ITranslationMoneyComponent ITranslationMoneyComponent { get; }
        public ITranslationPurchasesComponent ITranslationPurchasesComponent { get; }
        public ITranslationSalesComponent ITranslationSalesComponent { get; }
        public ITranslationSettingsComponent ITranslationSettingsComponent { get; }
        public ITranslationStaffComponent ITranslationStaffComponent { get; }
        public ITranslationWarehouseComponent ITranslationWarehouseComponent { get; } 

        public ITranslationEditStaffWindow ITranslationEditStaffWindow { get; }
        public ITranslationAddNewStaffWindow ITranslationAddNewStaffWindow { get; }

    }
}
