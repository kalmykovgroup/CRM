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

namespace KTSF.Components.Windows.SignInUserWinComponent.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInFormUC.xaml
    /// </summary>
    public partial class SignInFormUC : UserControl
    {  

        public SignInFormUC(SignInUserWinComponent component)
        {
            InitializeComponent();
            DataContext = component;
        }


        public void TextBoxChanged(object sender, TextChangedEventArgs e)
        {
            TextBlockError.Text = string.Empty;

            if (Validation.GetHasError((TextBox)sender) == true)
                BindingOperations.GetBindingExpression((TextBox)sender, TextBox.TextProperty).UpdateSource();

        }

        public void TextBoxLostFocus(object sender, RoutedEventArgs e) => BindingOperations.GetBindingExpression((TextBox)sender, TextBox.TextProperty).UpdateSource();

    }
}
