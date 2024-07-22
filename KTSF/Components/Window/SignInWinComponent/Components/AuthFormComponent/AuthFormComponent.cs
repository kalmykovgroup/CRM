 
using BarcodeStandard;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SignInFormComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
using QRCoder;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KTSF.Components.SignInPageComponent.Components.AuthFormComponent
{
    public partial class AuthFormComponent : Component
    {
        [ObservableProperty] private ImageSource? imageSource;
        [ObservableProperty] private bool isLoadQRCode = true;

        public AuthFormComponent(UserControlVM binding, AppControl appControl) : base(binding, appControl){}
 
        public override UserControl Initial() => new AuthFormUC(this);

        public override void ComponentLoaded()
        {
            //Сдесь открытый socket в который мы передаем два метода
           AppControl.Server.Authentication(GenerateBarCode, SetEmployee); 
        }

        //Метод вызовится когда сервер сгенерирует и пришлет QR code
        private void GenerateBarCode(string code)
        {  QRCodeGenerator qrGenerator = new QRCodeGenerator();
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
        private void SetEmployee(Employee employee)
        { 
          AuthSuccess?.Invoke(employee); //Вызывает метод, который слушает в ожидании момента входа 
        }

        #region Commands

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
        public void AppStoreClick(object? parameter){ 

            var destinationurl = "https://www.google.com/";
            var sInfo = new System.Diagnostics.ProcessStartInfo(destinationurl)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }
     
        #endregion
    }
}
