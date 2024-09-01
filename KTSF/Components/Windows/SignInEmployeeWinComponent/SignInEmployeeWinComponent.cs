using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CSharpFunctionalExtensions;
using KTSF.Core.Object;
using KTSF.Dto.Employee_;
using KTSF.ViewModel;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KTSF.Components.Windows.SignInEmployeeWinComponent
{
    public partial class SignInEmployeeWinComponent : Component
    {
        [ObservableProperty] private ImageSource? imageSource;
        [ObservableProperty] private bool isLoadQRCode = true;

        [ObservableProperty] private string? error;
        [ObservableProperty] private string? qRCode;
         

        public SignInEmployeeWinComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl){}

        public override UserControl Initial() => new SignInEmployeeWinUC(this);


        public async override void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (AppControl.Server.AnonymJwtToken != null)
            {
                //Здесь открытый socket в который мы передаем два метода
                 await AppControl.Server.RunWebSocketClientAuthEmployee(SuccessGenerateBarCode, FailureGenerateBarCode, SuccessAuthEmployee, FailureAuth);
            }
             
        } 

        private void FailureAuth(string? message, HttpStatusCode HttpStatusCode)
        {
            MessageBox.Show(message);         
        }

        private async void FailureGenerateBarCode(string? message, HttpStatusCode httpStatusCode)
        {
            BitmapImage logo = new BitmapImage();
            logo.BeginInit();
            logo.UriSource = new Uri("Img/error.png", UriKind.Relative);
            logo.EndInit();

            ImageSource = logo;

            if (httpStatusCode == HttpStatusCode.Unauthorized)
            {
                Error = message;
                //Regedit.DeleteAllData();
                await Task.Delay(3500);
                AppControl.SignInUserWinComponent.Show();
            }
 
        }

        //Метод вызовится когда сервер сгенерирует и пришлет QR code
        private void SuccessGenerateBarCode(string code)
        {
            this.QRCode = code;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream memory = new MemoryStream())
            {
                qrCodeImage.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                ImageSource = bitmapImage;
            }

            IsLoadQRCode = false;

        }

        //Метод вызоветься когда пользователь отсканирует QR code через приложение
        private void SuccessAuthEmployee(Employee employee)
        {
            Error = null;
            AppControl.Server.SetEmployeeJwtToken(employee.JwtToken);
            AppControl.Employee = employee;
            AppControl.MainMenuComponent.Show();
        }

        #region Commands

        [RelayCommand]
        public void CopyText()
        {
            Clipboard.SetText(QRCode);
        }

        public Action<Employee>? AuthSuccess;

        [RelayCommand]
        public void GooglePlayClick(object? parameter)
        {
            var destinationurl = "https://www.google.com/";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }

        [RelayCommand]
        public void AppStoreClick(object? parameter)
        {

            var destinationurl = "https://www.google.com/";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }


        [RelayCommand]
        public void NewQRCodeClick(object? parameter)
        {
            IsLoadQRCode = true;
            Error = null;
            ImageSource = null;
            //Здесь открытый socket в который мы передаем два метода
            AppControl.Server.RunWebSocketClientAuthEmployee(SuccessGenerateBarCode, FailureGenerateBarCode, SuccessAuthEmployee, FailureAuth);
        }

        #endregion
    }
}
