using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components.LoadComponent
{
    public class LoadVM : IComponent
    {
        public AppControl AppControl { get; }
         
        public LoadUC? LoadUC { get; private set; }

        public UserControl Build => LoadUC ?? Create();

        private UserControl Create()
        {
            LoadUC = new LoadUC(this);
            return LoadUC;
        }

        public LoadVM(AppControl appControl) {
            AppControl = appControl;          
        }

        public async void Run()
        {

            AppControl.NavMainMenuVM(); //Пропускаем авторизацию
            return;

            AppControl.IsLoad = "Подключение к интернету";

            await Task.Delay(0);
             
            AppControl.IsLoad = "Загрузка данных";

            await Task.Delay(0);

            AppControl.IsLoad = null;
             
            AppControl.NavSignIn();                   
        }
    }
}
