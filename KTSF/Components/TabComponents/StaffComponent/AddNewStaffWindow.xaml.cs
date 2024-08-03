using KTSF.Core;
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
using System.Windows.Shapes;

namespace KTSF
{
    /// <summary>
    /// Логика взаимодействия для AddNewUserWindow.xaml
    /// </summary>
    public partial class AddNewStaffWindow : Window
    {
        private Employee Employee { get; set; }

        public AddNewStaffWindow(Employee employee)
        {
            InitializeComponent();

            this.Employee = employee;
            DataContext = employee;
        }

        private void saveButtonButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {    
            DialogResult = false;
        }
    }
}
