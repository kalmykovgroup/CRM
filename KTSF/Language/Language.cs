using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSFClassLibrary.Language
{
    public class Language
    {
        public string Code { get; }
        public string Name { get; }

        public Language(string code, string name)
        {
            Code = code;
            Name = name;
        }


    }
}
