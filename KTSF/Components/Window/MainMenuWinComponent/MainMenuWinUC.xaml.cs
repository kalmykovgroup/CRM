using KTSF.Core.Language;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF.Components.Window.MainMenuComponent
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWinUC.xaml
    /// </summary>
    public partial class MainMenuWinUC : UserControl
    {
        public MainMenuWinComponent MainMenuWinComponent { get; }

        public MainMenuWinUC(MainMenuWinComponent mainMenuWinComponent)
        {
            InitializeComponent();
            MainMenuWinComponent = mainMenuWinComponent;
            DataContext = MainMenuWinComponent;

            MainMenuWinComponent.RequestClosePane += () =>
            {
                var storyboard = (Storyboard) FindResource ("CloseLeft");
                storyboard.Begin (this);
            };

            MainMenuWinComponent.RequestOpenPane += () =>
            {
                var storyboard = (Storyboard) FindResource ("Open");
                storyboard.Begin (this);
            };

        }

        //private void Languege_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    MainMenuWinComponent.AppControl.LanguageControl.Language = (Language)((ComboBox)sender).SelectedItem;
        //}
    }
     
}
