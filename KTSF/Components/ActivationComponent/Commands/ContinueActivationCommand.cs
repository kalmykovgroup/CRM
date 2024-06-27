﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KTSF.Components.ActivationComponent.Commands
{
    public class ContinueActivationCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public ActivationVM ActivationVM { get; }

        public ContinueActivationCommand(ActivationVM activationVM)
        {
            ActivationVM = activationVM;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            MessageBox.Show("ContinueActivationCommand");
        }
    }
}
