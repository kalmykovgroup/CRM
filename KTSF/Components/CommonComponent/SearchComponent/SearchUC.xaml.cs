﻿using System;
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

namespace KTSF.Components.CommonComponent.SearchComponent
{
    /// <summary>
    /// Логика взаимодействия для SearchUC.xaml
    /// </summary>
    public partial class SearchUC : UserControl
    {
        public SearchVM SearchVM { get; }

        public SearchUC(SearchVM searchVM)
        {
            SearchVM = searchVM;
            DataContext = searchVM;
            InitializeComponent();
        }

        private void TextBox_TextChanged (object sender, TextChangedEventArgs e) => SearchVM.TextBox_TextChanged(sender, e);
    }
}
