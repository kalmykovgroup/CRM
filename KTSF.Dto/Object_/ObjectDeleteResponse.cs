using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace KTSF.Dto.Object_
{
    public class ObjectDeleteResponse(bool? result, string? error = null)
    {
        public bool? result = result;
        public string? error = error;
    }
}
