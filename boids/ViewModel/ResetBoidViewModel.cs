using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    class ResetBoidViewModel : ICommand
    {
        SimulationViewModel simVm;

        public ResetBoidViewModel(SimulationViewModel simVm)
        {
            this.simVm = simVm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var list = simVm.sim.World.Population;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                list.RemoveAt(i);
            }
                
            }
    }
}
