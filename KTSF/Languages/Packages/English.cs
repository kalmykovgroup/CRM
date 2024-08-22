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

namespace KTSF.Languages.Packages
{
    public class English : ILanguage
    {

        private class TranslationCashiersWorkplaceComponent : ITranslationCashiersWorkplaceComponent
        {
            public string Name => "Cashiers workplace";

            public string LabelBtnCard => "Card";
            public string LabelBtnCash => "Cash";
        }

        public ITranslationCashiersWorkplaceComponent ITranslationCashiersWorkplaceComponent => new TranslationCashiersWorkplaceComponent();

        private class TranslationCompanyComponent : ITranslationCompanyComponent
        {
            public string Name => "Company";
        }

        public ITranslationCompanyComponent ITranslationCompanyComponent => new TranslationCompanyComponent();

        private class TranslationMoneyComponent : ITranslationMoneyComponent
        {
            public string Name => "Money";
        }

        public ITranslationMoneyComponent ITranslationMoneyComponent => new TranslationMoneyComponent();

        private class TranslationPurchasesComponent : ITranslationPurchasesComponent
        {
            public string Name => "Purchases";
        }

        public ITranslationPurchasesComponent ITranslationPurchasesComponent => new TranslationPurchasesComponent();

        private class TranslationSalesComponent : ITranslationSalesComponent
        {
            public string Name => "Sales";
        }

        public ITranslationSalesComponent ITranslationSalesComponent => new TranslationSalesComponent();

        private class TranslationSettingsComponent : ITranslationSettingsComponent
        {
            public string Name => "Settings";
        }

        public ITranslationSettingsComponent ITranslationSettingsComponent => new TranslationSettingsComponent();

        private class TranslationStaffComponent : ITranslationStaffComponent
        {
            public string Name => "Staff";
        }

        public ITranslationStaffComponent ITranslationStaffComponent => new TranslationStaffComponent();

        private class TranslationWarehouseComponent : ITranslationWarehouseComponent
        {
            public string Name => "Warehouse";
        }

        public ITranslationWarehouseComponent ITranslationWarehouseComponent => new TranslationWarehouseComponent();


        private class TranslationSearchComponent : ITranslationSearchComponent
        {
            public string Placeholder => "Search"; 
        }

        public ITranslationSearchComponent ITranslationSearchComponent => new TranslationSearchComponent();

      
    }
}
