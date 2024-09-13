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
using KTSF.Components.CommonComponents.PaginateComponent;

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
            public string Title => "Receipts";
            public string Date => "Date";
            public string Number => "Number";
            public string Sum => "Sum";
            public string Return => "Return";
            public string Status => "Status";
            public string FixedCheckNumber => "№ Check";
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
            public string Employed => "Employed";
            public string Fired => "Fired";
            public string Unemployed => "Unemployed";
            public string Search => "Search";
            public string ProbationPeriod => "Probation period";
            public string Add => "Add";
            public string Edit => "Edit";
            public string MoreDetailed => "More detailed";
            public string PhoneNumber => "Phone number";
            public string Email => "Email";
            public string Address => "Address :";
            public string Passport => "Passport :";
            public string INN => "INN :";
            public string SNILS => "SNILS :";
            public string DateOfEmployment => "Date of employment :";
            public string DateOfEditing => "Date of editing :";
            public string DateOfLayoff => "Date of layoff :";
            

            string ITranslationStaffComponent.DateOfEmployment => throw new NotImplementedException();
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
        
        private class TranslationPaginateComponent : ITranslationPaginateComponent
        {
            public string Page => "Page"; 
            public string CountOf => "of"; 
        }

        public ITranslationPaginateComponent ITranslationPaginateComponent => new TranslationPaginateComponent();

        private class TranslationEditStaffWindow : ITranslationEditStaffWindow
        {
            public string Name => "Name :";
            public string Surname => "Surname :";
            public string Patronymic => "Patronymic :";
            public string Passport => "Passport :";
            public string INN => "INN :";
            public string SNILS => "SNILS :";
            public string Position => "Position :";
            public string PhoneNumber => "PhoneNumber :";
            public string Email => "Email :";
            public string Address => "Address :";
            public string EmployeeStatus => "Employee status :";
            public string EmployeePermissions => "Employee permissions :";
            public string ApplyingDate => "Applying date :";
            public string Editing => "Editing";
            public string Attributes => "Attributes";
            public string Save => "Save";
            public string Cancel => "Cancel";
        }

        public ITranslationEditStaffWindow ITranslationEditStaffWindow => new TranslationEditStaffWindow();


        private class TranslationAddNewStaffWindow : ITranslationAddNewStaffWindow
        {
            public string Name => "Name :";
            public string Surname => "Surname :";
            public string Patronymic => "Patronymic :";
            public string Passport => "Passport :";
            public string INN => "INN :";
            public string SNILS => "SNILS :";
            public string Position => "Position :";
            public string PhoneNumber => "PhoneNumber :";
            public string Email => "Email :";
            public string Address => "Address :";
            public string EmployeeStatus => "Employee status :";
            public string EmployeePermissions => "Employee permissions :";
            public string ApplyingDate => "Applying date :";            
            public string Save => "Save";
            public string Cancel => "Cancel";
        }

        public ITranslationAddNewStaffWindow ITranslationAddNewStaffWindow => new TranslationAddNewStaffWindow();
    }
}
