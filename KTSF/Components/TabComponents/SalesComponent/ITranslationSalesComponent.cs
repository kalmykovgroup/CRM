using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.TabComponents.SalesComponent
{
    public interface ITranslationSalesComponent
    {
        public string Name { get; }
        public string Title { get; }
        public string Date { get; }
        public string Number { get; }
        public string Sum { get; }
        public string Return { get; }
        public string Status { get; }
        public string FixedCheckNumber { get; }
    }
}
