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
using KTSF.Components.Windows.MainMenuComponent;
using KTSF.Languages;
using KTSF.Languages.Model;
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

namespace KTSF.Core.Language
{
    public partial class LanguageControl: ObservableObject
    {  
        private Language language;
        public Language Language { get => language; set {
            language = value;
                LanguageChange?.Invoke();
        } }

        public Action? LanguageChange;

        public List<Language> Select { get; } = new(); 

        public LanguageControl()
        {
             Language = new RusLanguage();
             Select.Add(Language);
             Select.Add(new EngLanguage());

            string? code = Regedit.GetValue("language")!;
            Language = Select.Where(language => language.Code == code).FirstOrDefault() ?? Language;
        } 

 
    }
}
