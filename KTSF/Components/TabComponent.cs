using KTSF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace KTSF.Components;

public abstract class TabComponent : Component
{

    public virtual string IconPath { get; set; }

    public TabComponent(UserControlVM binding, AppControl appControl, string iconPath) : base(binding, appControl) 
    {
        IconPath = iconPath;
    }
     
    
    public virtual ImageSource? Icon => new BitmapImage(new Uri("/Img/warning.png"));
}
