using KTSFClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KTSF.Components.SignInComponent.Commands
{
    public class SignInCommand : ICommand
    {
        private SignInVM SignInVM {  get; }

        public SignInCommand(SignInVM signInVM)
        {
            SignInVM = signInVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => true;

        public  void Execute(object? parameter)
        {
          

         

            
        }
    }
}
