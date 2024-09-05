
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.TabComponents.WarehouseComponent
{
    public interface ITranslationWarehouseComponent
    {
       public string Name { get; }

       public string Nomenclature { get; }

       public string Title { get; }

       public string RetailPrice { get; }

       public string Remains { get; }

       public string Unit { get; }

       public string Article { get; }

    }
}
