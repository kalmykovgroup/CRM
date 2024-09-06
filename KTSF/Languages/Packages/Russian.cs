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
            public string Title => "Чеки";
            public string Date => "Дата";
            public string Number => "Номер";
            public string Sum => "Сумма";
            public string Return => "Возрат";
            public string Status => "Статут";
            public string FixedCheckNumber => "№ фиксального чека";
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
            public string Employed => "Трудоустроен";
            public string Fired => "Уволенные";
            public string Unemployed => "Не трудоустроен";
            public string ProbationPeriod => "Испытательный срок";
            public string Add => "Добавить";
            public string Edit => "Редактировать";
            public string MoreDetailed => "Подробнее";
            public string PhoneNumber => "Телефон";
            public string Email => "Почта";
            public string Address => "Адрес :";
            public string Passport => "Паспорт :";
            public string INN => "ИНН :";
            public string SNILS => "СНИЛС";
            public string DateOfEmployment => "Дата трудоустройства :";
            public string DateOfEditing => "Дата редактирования :";
            public string DateOfLayoff => "Дата увольнения :";
        }

        public ITranslationStaffComponent ITranslationStaffComponent => new TranslationStaffComponent();

        private class TranslationWarehouseComponent : ITranslationWarehouseComponent
        {
            public string Name => "Склад";
        }

        public ITranslationWarehouseComponent ITranslationWarehouseComponent => new TranslationWarehouseComponent();



        private class TranslationEditStaffWindow : ITranslationEditStaffWindow
        {
            public string Name => "Имя :";
            public string Surname => "Фамилия :";
            public string Patronymic => "Отчество :";
            public string Passport => "Паспорт :";
            public string INN => "ИНН :";
            public string SNILS => "СНИЛС :";
            public string Position => "Должность :";
            public string PhoneNumber => "Телефон :";
            public string Email => "Почта :";
            public string Address => "Адрес :";
            public string EmployeeStatus => "Статус сотрудника :";
            public string EmployeePermissions => "Разрешения сотрудника :";
            public string ApplyingDate => "Дата оформления :";
            public string Editing => "Редактирование";
            public string Attributes => "Атрибуты";
            public string Save => "Сохранить";
            public string Cancel => "Отмена";
        }

        public ITranslationEditStaffWindow ITranslationEditStaffWindow => new TranslationEditStaffWindow();


        private class TranslationAddNewStaffWindow : ITranslationAddNewStaffWindow
        {
            public string Name => "Имя :";
            public string Surname => "Фамилия :";
            public string Patronymic => "Отчество :";
            public string Passport => "Паспорт :";
            public string INN => "ИНН :";
            public string SNILS => "СНИЛС :";
            public string Position => "Должность :";
            public string PhoneNumber => "Телефон :";
            public string Email => "Почта :";
            public string Address => "Адрес :";
            public string EmployeeStatus => "Статус сотрудника :";
            public string EmployeePermissions => "Разрешения сотрудника :";
            public string ApplyingDate => "Дата оформления :";           
            public string Save => "Сохранить";
            public string Cancel => "Отмена";
        }

        public ITranslationAddNewStaffWindow ITranslationAddNewStaffWindow => new TranslationAddNewStaffWindow();

    }
}
