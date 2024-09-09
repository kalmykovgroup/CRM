using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SearchComponent;
using KTSF.Core.Language;
using KTSF.ViewModel; 
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Reflection;
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

        //public нужен для mainWinComponent (Мы не можем брать Build так как произойдет инициализаци
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

        public virtual SeparateTabMode SeparateTabMode { get; }

        private UserControlVM binding;

        [ObservableProperty] private string? name;

        private void Ini() {
            if (!BeforLoaded()) return;
            UserControl = Initial();
            UserControl.Loaded += UserControl_Loaded;

            ComponentLoaded();
        }

        public virtual bool BeforLoaded() => true;

        public virtual void ComponentLoaded() { }
         
        public virtual void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e) { }

        public abstract UserControl Initial();


        private dynamic? property;

        public dynamic? Property { 
            get => property;
            set
            {
                SetProperty(ref property, value); 
            }
        }


       

        public static void LoadLanguage(Type type, AppControl AppControl, Action<dynamic> actionResult)
        {

            string? name = type.Name;

            PropertyInfo? propertyInfo = AppControl.LanguageControl.Language.Pack.GetType().GetProperty($"ITranslation{name}");

            object? obj = propertyInfo?.GetValue(AppControl.LanguageControl.Language.Pack);

            if (obj is null) return;


            dynamic dynamicObject = new ExpandoObject();


            var propertyList = obj.GetType().GetProperties();

            foreach (var property in propertyList)
            {
                object text = property.GetValue(obj) ?? "No name";

                ((IDictionary<string, object>)dynamicObject)[property.Name] = text;
            }
            actionResult.Invoke(dynamicObject);

        }



        public Component(UserControlVM binding, AppControl appControl)
        {
            SeparateTabMode = SeparateTabMode.Off;

            this.binding = binding;
            AppControl = appControl;

            LoadLanguage(this.GetType(), AppControl, (_property) => { Property = _property; });

            AppControl.LanguageControl.LanguageChange += () => LoadLanguage(this.GetType(), AppControl, (_property) => { Property = _property; });


        }

        protected Component()
        {
            throw new NotImplementedException();
        }


        [RelayCommand]
        public virtual void Show(object? parameter = null)
        {
            binding.UserControl = Build;

            if(SeparateTabMode == SeparateTabMode.Multy)
            {
                History.Add(this);

            }else if (SeparateTabMode == SeparateTabMode.One)
            {

            }     
        }
        
 
       
    }
}
