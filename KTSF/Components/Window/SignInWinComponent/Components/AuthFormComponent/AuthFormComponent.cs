 
using BarcodeStandard;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KTSF.Components.CommonComponents.SignInFormComponent;
using KTSF.ViewModel;
using KTSFClassLibrary;
using SkiaSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        {
           

            var b = new Barcode();
            b.IncludeLabel = true;
            SKImage image = b.Encode(BarcodeStandard.Type.Code128, code, SKColors.Black, SKColors.White, 290, 120);
             
            // encode the image (defaults to PNG)
            SKData encoded = image.Encode();
            // get a stream over the encoded data
            Stream stream = encoded.AsStream();
             
             
             
            using (MemoryStream memory = new MemoryStream())
            {
                ImageSource = BitmapFrame.Create(stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
            }

            IsLoadQRCode = false;

        }

        //Метод вызоветься когда пользователь отсканирует QR code через приложение
        private void SetEmployee(Employee employee)
        { 
          //AuthSuccess?.Invoke(employee); //Вызывает метод, который слушает в ожидании момента входа 
        }

        #region Commands

        public Action<Employee>? AuthSuccess;

        [RelayCommand]
        public void GooglePlayClick(object? parameter)
        {
            MessageBox.Show("GooglePlay");
        }

        [RelayCommand]
        public void AppStoreClick(object? parameter){
            MessageBox.Show("AppStore");
        }
     
        #endregion
    }
}
