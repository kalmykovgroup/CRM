﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Dto.Object_
{
    public class ObjectSelectResponse(string? anonymJwtToken, string? error = null)
    {
        public string? AnonymJwtToken { get; set; } = anonymJwtToken; 

        public string? Error { get; set; } = error;
         
    }
}
