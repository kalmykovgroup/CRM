using KTSF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Application.Service
{
    public class AuthSingletonService
    {
        public Dictionary<string, AuthSocketData> OpensWebSockets = new ();

    }
}
