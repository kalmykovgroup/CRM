using KTSF.Core.Language;
using KTSF.Languages.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Languages.Model
{
    public class EngLanguage : Language
    {
        public override string Name => "English";
        public override string Code => "eng";

        private ILanguage? pack;

        public override ILanguage Pack
        {
            get
            {

                if (pack == null)
                {
                    pack = new English();
                }

                return pack;
            }
        } 
         
    }
}
