
using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.SignInComponent
{
    public class SignIn
    {
        public User User { get; }
        public SignIn(User user)
        {
            User = user;
        }
    }
}
