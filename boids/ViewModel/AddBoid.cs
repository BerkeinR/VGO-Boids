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
        private SimulationViewModel simVM;

        public AddBoid(SimulationViewModel simVM)
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
            switch ((String)parameter)
            {
                case "hunter":
                    simVM.sim.Species[0].CreateBoid(new Vector2D(generateRandom(1500), generateRandom(1000)));
                    break;
                case "prey":
                    simVM.sim.Species[1].CreateBoid(new Vector2D(generateRandom(1500), generateRandom(1000)));
                    break;
                case "leech":
                    simVM.sim.Species[2].CreateBoid(new Vector2D(generateRandom(1500), generateRandom(1000)));
                    break;
            }
        }

        public int generateRandom(int range)
        {
            int rInt = r.Next(0, range);
            Console.WriteLine(rInt);
            return rInt;
        }
        private Random r = new Random();
    }
}
