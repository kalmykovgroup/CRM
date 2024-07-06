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

namespace KTSF.Components.CommonComponents.SearchComponent
{
    /// <summary>
    /// Логика взаимодействия для SearchUC.xaml
    /// </summary>
    public partial class SearchUC : UserControl
    {
        public SearchComponent SearchComponent { get; }
        public SearchUC(SearchComponent searchComponent)
        {
            InitializeComponent();
            SearchComponent = searchComponent;
            DataContext = SearchComponent;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e) => SearchComponent.TextBox_TextChanged(sender, e);

    }
}
