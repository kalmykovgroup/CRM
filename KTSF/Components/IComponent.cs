using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components
{
    interface IComponent
    {
        public abstract AppControl AppControl { get; }
        public abstract UserControl UserControl { get; }
        public abstract void Run();
    }
}
