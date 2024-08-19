using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KTSF.Components
{
    public enum SeparateTabMode { Off, One, Multy};

    public interface IComponent
    {
        public AppControl AppControl { get; }
        public UserControl? Build { get; } 
        public string? Name { get; set; }

        public void Show(object? parametr);

        public SeparateTabMode SeparateTabMode { get; }

    }
}
