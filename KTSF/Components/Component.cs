using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.ViewModel; 
using System;
using System.Collections.Generic;
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
        
        public AppControl AppControl { get; }

        private UserControl? userControl; 

        [ObservableProperty] private string? isLoad;

        public UserControl? Build => userControl ?? Ini();

        private UserControlVM binding;        

        public string? Name { get; set; }

        private UserControl Ini() {
            UserControl_PreLoaded(); //Для возможности запуска предварительных функций
            userControl = Initial(); 
            userControl.Loaded += UserControl_Loaded; 
            return userControl;
        }

        public virtual void UserControl_PreLoaded(){}
        public virtual void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e){}

        public abstract UserControl Initial();
         

        public Component(UserControlVM binding, AppControl appControl)
        {
            this.binding = binding;
            AppControl = appControl;
        }


        public virtual ImageSource? Icon => new BitmapImage(new Uri("/Img/warning.png"));

        private UserControl? iconBtnUC;

        //Инициализируем кнопки только у тех компонентов, у которых мы ее запрашиваем для навигации
        public virtual UserControl? IconBtn
        {
            get
            {
                if (iconBtnUC == null) iconBtnUC = new IconBtn(this);
                return iconBtnUC;
            }
        }

        private UserControl? textBtnUC;

        //Инициализируем кнопки только у тех компонентов, у которых мы ее запрашиваем для навигации
        public virtual UserControl? TextBtn
        {
            get
            {
                if (textBtnUC == null) textBtnUC = new TextBtn(this);
                return textBtnUC;
            }
        }

        private UserControl? iconTextUC;

        //Инициализируем кнопки только у тех компонентов, у которых мы ее запрашиваем для навигации
        public virtual UserControl? IconTextBtn
        {
            get
            {
                if (iconTextUC == null) iconTextUC = new IconTextBtn(this);
                return iconTextUC;
            }
        }
         
 

        public abstract Component FactoryMethod(UserControlVM binding, AppControl appControl, object? data = null);

        [RelayCommand]
        public void Show(object? parametr = null) => binding.UserControl = Build;
        

        public override string ToString() => Name ?? "No name"; 

       
    }
}
