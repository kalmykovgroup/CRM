using KTSF.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Core.Language
{
    public abstract class Language
    {
        public abstract string Code { get; }
        public abstract string Name { get; }

        public abstract ITranslation Pack { get; }

        public override string ToString() => Name;
    }
}
