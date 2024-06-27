using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.SignInComponent.Commands
{
    public class SignInCommands
    {
        public SignInCommand SignInCommand { get; } 


        public SignInCommands(SignInVM signInVM)
        {
            SignInCommand = new SignInCommand(signInVM); 
        }
    }
}
