using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.Language
{
    public class LanguageTranslation
    {
        public string Component { get; }
        public Dictionary<Language, string> Translations { get; }

        public LanguageTranslation(string component, Dictionary<Language, string> translations)
        {
            Component = component;
            Translations = translations;
        }
    }
}
