using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.TabComponents.CashiersWorkplaceComponent
{
    public interface ITranslationCashiersWorkplaceComponent
    {
        public string Name { get; }
        public string LabelBtnCard { get; }
        public string LabelBtnCash { get; }
    }
}
