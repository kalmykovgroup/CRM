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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF.Components.MainMenuComponent.Components.AdministrationComponent.Components.StatisticsPageComponent
{
    /// <summary>
    /// Логика взаимодействия для StatisticsPageUC.xaml
    /// </summary>
    public partial class StatisticsPageUC : UserControl //MainMenuVM -> AdministrationVM -> StatisticsPageVM
    {
        public StatisticsPageVM StatisticsVM { get; }

        public StatisticsPageUC(StatisticsPageVM statisticsVM)
        {
            StatisticsVM = statisticsVM;
            DataContext = statisticsVM;
            InitializeComponent();
        }
    }
}
