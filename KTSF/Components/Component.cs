using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.ViewModel;
using KTSFClassLibrary.Language;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.TextFormatting;
using System.Xml.Linq;

namespace KTSF.Components
{
    public abstract partial class Component : ObservableObject, IComponent
    {
         
        public static ObservableCollection<Component> History = new();

     
        public AppControl AppControl { get; }

        public UserControl? UserControl { get; private set; }

        [ObservableProperty] private string? isLoad;

        public UserControl? Build
        {
            get
            {
                if (UserControl == null)
                {
                    Ini();
                }

                return UserControl;

            }
        }


        private UserControlVM binding;

        public string? Name { get; set; }

        private void Ini() {
            UserControl = Initial();
            UserControl.Loaded += UserControl_Loaded;
     
            ComponentLoaded();
        }

        public virtual void ComponentLoaded() { }
         
        public virtual void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e) { }

        public abstract UserControl Initial();


        public Component(UserControlVM binding, AppControl appControl)
        {
            this.binding = binding;
            AppControl = appControl;

            Type type = this.GetType();
            //Устанавливаем ему языл
            foreach (LanguageTranslation languageTranslation in this.AppControl.Languages.LanguageTranslations)
            {
                if (languageTranslation.Component == type.Name)
                {
                    foreach (var item in languageTranslation.Translations)
                    {
                        if (item.Key.Code == this.AppControl.Languages.Selected.Code)
                        {
                            this.Name = item.Value;
                        }
                    }
                }

            }

        }



        [RelayCommand]
        public virtual void Show(object? parametr = null)
        {
            binding.UserControl = Build;
            History.Add(this);
        }
        

        public override string ToString() => Name ?? this.GetType().Name; 

       
    }
}
