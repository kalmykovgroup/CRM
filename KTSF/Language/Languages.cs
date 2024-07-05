using CommunityToolkit.Mvvm.ComponentModel;
using KTSF;
using KTSF.Components.CommonComponents.CashiersWorkplaceComponent;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.Components.MainMenuComponent;
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

            Regester(new(nameof(MainMenuComponent), new() {

                    { rus , "Меню" },
                    { eng, "Menu" },
            }));

            Regester(new(nameof(SearchComponent), new() {

                    { rus , "Поиск" },
                    { eng, "Search" },
            }));
        }

       
         

      

      
    }
}
