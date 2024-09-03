 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = KTSF.Core.App.Object;

namespace KTSF.Dto.Object_
{
    public class ObjectCreateResponse(Object? @object, string? error = null)
    {
        public Object? @object = @object;
        public string? error = error;
    }
}
