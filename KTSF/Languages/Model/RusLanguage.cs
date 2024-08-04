using KTSF.Core.Language;
using KTSF.Languages.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Languages.Model
{
    public class RusLanguage : Language
    {
        public override string Name => "Русский";
        public override string Code => "rus";

        private ILanguage? pack;

        public override ILanguage Pack
        {
            get
            {

                if (pack == null)
                {
                    pack = new Russian();
                }

                return pack;
            }
        }
    }
}
