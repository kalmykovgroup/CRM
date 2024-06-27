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
         
        public UserControl UserControl { get; }

        public LoadVM(AppControl appControl) {
            AppControl = appControl;
            UserControl = new LoadUC(this);
        }

        public async void Run()
        {
            AppControl.UserControl = UserControl;

            AppControl.IsLoad = "Подключение к интернету";

            await Task.Delay(0);
             
            AppControl.IsLoad = "Загрузка данных";

            await Task.Delay(0);

            AppControl.IsLoad = null;

             
            AppControl.NavSignIn();
            

            
        }
    }
}
