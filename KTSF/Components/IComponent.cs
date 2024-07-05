using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components
{
    public interface IComponent
    {
        public AppControl AppControl { get; }
        public UserControl? Build { get; } 
        public string? Name { get; set; }

        public void Show(object? parametr);

    }
}
