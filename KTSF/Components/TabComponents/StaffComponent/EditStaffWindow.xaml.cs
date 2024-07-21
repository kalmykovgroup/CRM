using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditStaffWindow.xaml
    /// </summary>
    public partial class EditStaffWindow : Window
    {
        private Employee Employee;

        private Regex nameRegex = new(@"[A-ZА-Я]{1}[a-zа-я]+"); // имя фамилия отчество
        private Regex passportSeriesRegex = new(@"\d{4}");
        private Regex passportNumberRegex = new(@"\d{6}");
        private Regex innNumberRegex = new(@"\d{12}");
        private Regex snilsRegex = new(@"\d{11}");
        private Regex phoneNumberRegex = new(@"(\+7|8)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)");
        private Regex emailRegex = new(@"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*\.\w{2,3}$");

        public EditStaffWindow(Employee employee)
        {
            InitializeComponent();
            this.Employee = employee;

            this.DataContext = Employee;
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
