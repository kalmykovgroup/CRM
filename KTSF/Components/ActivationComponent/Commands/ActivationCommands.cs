using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTSF.Components.ActivationComponent.Commands
{
    public class ActivationCommands
    {
        public StartActivationCommand StartActivationCommand { get; }
        public ContinueActivationCommand ContinueActivationCommand { get; }

        public ActivationCommands(ActivationVM activationVM) {
            StartActivationCommand = new StartActivationCommand(activationVM);
            ContinueActivationCommand = new ContinueActivationCommand(activationVM);
        }
    }
}
