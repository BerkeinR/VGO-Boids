using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Mathematics;

namespace ViewModel
{
    class AddBoid : ICommand
    {
        private SimulationViewModel viewModel;

        public AddBoid(SimulationViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch ((String)parameter)
            {
                case "hunter":
                    viewModel.sim.Species[0].CreateBoid(new Vector2D(100, 200));
                    break;
                case "prey":
                    viewModel.sim.Species[1].CreateBoid(new Vector2D(100, 200));
                    break;
            }
        }
    }
}
