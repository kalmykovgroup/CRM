using KTSF.Components;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.ViewModel
{
    public class LinkToComponent
    {
        public string ClassName { get; } 
        public string ComponentName { get; } 
        Func<UserControlVM, AppControl, object?, Component> FactoryMethod { get; }

        public LinkToComponent(string className, string componentName, Func<UserControlVM, AppControl, object?, Component> factoryMethod)
        {
            ClassName = className;
            ComponentName = componentName;
            FactoryMethod = factoryMethod;
        }

    }
}
