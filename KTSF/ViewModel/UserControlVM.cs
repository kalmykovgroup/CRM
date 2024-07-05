using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.ViewModel
{
    public partial class UserControlVM: ObservableObject
    {
        [ObservableProperty] public UserControl? userControl;

        public UserControlVM(UserControl? userControl = null) {
            UserControl = userControl;
        }
    }
}
