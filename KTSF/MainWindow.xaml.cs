using KTSF.Components.Window.MainMenuComponent;
using KTSF.Core.Language;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KTSF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppControl AppControl { get; }

        public MainWindow()
        {
            InitializeComponent();

            AppControl = new AppControl(this);
            DataContext = AppControl; 
        }

        private void Border_MouseDown (object sender, MouseButtonEventArgs e) {
            if (e.ChangedButton == MouseButton.Left) {
                DragMove ();
            }
        }

        private void btnMinimize_Click (object sender, RoutedEventArgs e) {
            WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click (object sender, RoutedEventArgs e) {
            if(WindowState == WindowState.Normal) {
                WindowState = WindowState.Maximized;
            }   
            else {
                WindowState = WindowState.Normal;
            }   
        }

        private void btnClose_Click (object sender, RoutedEventArgs e) {
            Application.Current.Shutdown ();
        }

        private void Language_SelectionChanged (object sender, SelectionChangedEventArgs e) {
            AppControl.LanguageControl.Language = (Language) ((ComboBox) sender).SelectedItem;
        }
    }
}