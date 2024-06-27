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

namespace KTSF.Components.LoadComponent
{
    /// <summary>
    /// Логика взаимодействия для LoadUC.xaml
    /// </summary>
    public partial class LoadUC : UserControl
    {
        public LoadVM LoadVM { get; }

        public LoadUC(LoadVM loadVM)
        {
            LoadVM = loadVM;
            DataContext = loadVM;
            InitializeComponent();


        }
    }
}
