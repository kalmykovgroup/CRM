using CommunityToolkit.Mvvm.ComponentModel;
using KTSF;
using KTSF.Components.CommonComponents.SearchComponent; 
using KTSF.Components.TabComponents.CashiersWorkplaceComponent;
using KTSF.Components.TabComponents.CompanyComponent; 
using KTSF.Components.TabComponents.MoneyComponent;
using KTSF.Components.TabComponents.PurchasesComponent;
using KTSF.Components.TabComponents.SalesComponent;
using KTSF.Components.TabComponents.SettingsComponent;
using KTSF.Components.TabComponents.StaffComponent;
using KTSF.Components.TabComponents.WarehouseComponent;
using KTSF.Components.Window.MainMenuComponent;
using KTSF.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Windows;

namespace KTSFClassLibrary.Language
{
    public partial class Languages: ObservableObject
    {
        private Language selected; 
        public Language Selected { get => selected; set
            {
                SetProperty(ref selected, value);
            }
        }

        public List<Language> List { get; } = new();
        public List<LanguageTranslation> LanguageTranslations { get; } = new();

        public Languages()
        {
          
            Language rus = new Language("rus", "Русский");
            Language eng = new Language("eng", "English");

            List.Add(rus);
            List.Add(eng); 
            
            selected = rus;

            Initial(rus, eng);

            string? code = Regedit.GetValue("language")!;
            Selected = List.Where(language => language.Code == code).FirstOrDefault() ?? Selected;
        }
        public void Regester(LanguageTranslation languageTranslation) => LanguageTranslations.Add(languageTranslation);


        public void Initial(Language rus, Language eng)
        {
            Regester(new(nameof(CashiersWorkplaceComponent), new() {

                    { rus , "Рабочее место кассира" },
                    { eng, "Cashiers workplace" },
            }));

            Regester(new(nameof(MainMenuWinComponent), new() {

                    { rus , "Меню" },
                    { eng, "Menu" },
            }));

            Regester(new(nameof(SearchComponent), new() {

                    { rus , "Поиск" },
                    { eng, "Search" },
            }));
             

            Regester(new(nameof(CompanyComponent), new() {

                    { rus , "Компания" },
                    { eng, "Company" },
            }));
             
            Regester(new(nameof(WarehouseComponent), new() {

                    { rus , "Склад" },
                    { eng, "Warehouse" },
            }));

            Regester(new(nameof(MoneyComponent), new() {

                    { rus , "Деньги" },
                    { eng, "Money" },
            }));

            Regester(new(nameof(PurchasesComponent), new() {

                    { rus , "Закупка" },
                    { eng, "Purchases" },
            }));

            Regester(new(nameof(SalesComponent), new() {

                    { rus , "Продажи" },
                    { eng, "Sales" },
            }));
            Regester(new(nameof(SettingsComponent), new() {

                    { rus , "Настройки" },
                    { eng, "Settings" },
            }));
            Regester(new(nameof(StaffComponent), new() {

                    { rus , "Персонал" },
                    { eng, "Staff" },
            }));
        }

       
         

      

      
    }
}
