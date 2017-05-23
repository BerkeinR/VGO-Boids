using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class exitCommand : ICommand
    {
        private SimulationViewModel simVM;

        public event Action ApplicationExit;

        public exitCommand(SimulationViewModel simVM)
        {
            this.simVM = simVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ApplicationExit?.Invoke();
        }
    }
}
