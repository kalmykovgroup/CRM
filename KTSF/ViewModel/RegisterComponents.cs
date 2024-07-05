using KTSF.Components;
using KTSFClassLibrary.Language;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace KTSF.ViewModel
{
    public static class RegisterComponents
    {
        
        public static List<LinkToComponent> Components = new();

      
        public static void Register(this Component component)
        {
            Type type = component.GetType();

            if (type.Name is null) throw new ArgumentNullException("type");

            //Если такой компонент еще не был 
            if (!Components.Any(component => component.ClassName == type.Name))
            {
               //Устанавливаем ему языл
               foreach(LanguageTranslation languageTranslation in component.AppControl.Languages.LanguageTranslations)
                {
                    if(languageTranslation.Component == type.Name)
                    {
                        foreach (var item in languageTranslation.Translations){
                            if(item.Key.Code == component.AppControl.Languages.Selected.Code)
                            {
                                component.Name = item.Value;
                            }
                        }
                    }
                  
                }
               

              Components.Add(new LinkToComponent(type.Name, component.ToString(), component.FactoryMethod));
            }

             


        }

    }
   
}
