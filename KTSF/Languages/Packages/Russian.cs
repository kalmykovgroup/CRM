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
    public class Russian : ILanguage
    {
 

        private class TranslationSearchComponent : ITranslationSearchComponent
        {
            public string Placeholder => "Поиск"; 
        }

        public ITranslationSearchComponent ITranslationSearchComponent => new TranslationSearchComponent();

        private class TranslationCashiersWorkplaceComponent : ITranslationCashiersWorkplaceComponent
        {
            public string Name => "Рабочее место кассира";
            public string LabelBtnCard => "Карта";
            public string LabelBtnCash => "Наличные";
        }

        public ITranslationCashiersWorkplaceComponent ITranslationCashiersWorkplaceComponent => new TranslationCashiersWorkplaceComponent();

        private class TranslationCompanyComponent : ITranslationCompanyComponent
        {
            public string Name => "Компания";
        }

        public ITranslationCompanyComponent ITranslationCompanyComponent => new TranslationCompanyComponent();

        private class TranslationMoneyComponent : ITranslationMoneyComponent
        {
            public string Name => "Деньги";
        }

        public ITranslationMoneyComponent ITranslationMoneyComponent => new TranslationMoneyComponent();

        private class TranslationPurchasesComponent : ITranslationPurchasesComponent
        {
            public string Name => "Закупки";
        }

        public ITranslationPurchasesComponent ITranslationPurchasesComponent => new TranslationPurchasesComponent();

        private class TranslationSalesComponent : ITranslationSalesComponent
        {
            public string Name => "Продажи";
        }

        public ITranslationSalesComponent ITranslationSalesComponent => new TranslationSalesComponent();

        private class TranslationSettingsComponent : ITranslationSettingsComponent
        {
            public string Name => "Настройки";
        }

        public ITranslationSettingsComponent ITranslationSettingsComponent => new TranslationSettingsComponent();

        private class TranslationStaffComponent : ITranslationStaffComponent
        {
            public string Name => "Персонал";
        }

        public ITranslationStaffComponent ITranslationStaffComponent => new TranslationStaffComponent();

        private class TranslationWarehouseComponent : ITranslationWarehouseComponent
        {
            public string Name => "Склад";
        }

        public ITranslationWarehouseComponent ITranslationWarehouseComponent => new TranslationWarehouseComponent();

      
    }
}
