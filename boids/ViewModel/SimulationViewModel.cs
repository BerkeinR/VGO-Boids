using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Mathematics;
using System.ComponentModel;
using Microsoft.Practices.ServiceLocation;
using Service;
using System.Windows.Input;
using Cells;
using Bindings;

namespace ViewModel
{
    public class SimulationViewModel : INotifyPropertyChanged
    {

        public Simulation sim { get; set; }

        public ICommand AddBoid { get; set; }
        public ICommand exitCommand { get; set; }
        public Cell<double> speedCell { get; set; }
        public SliderManager manager { get; set; }
        public ICommand timer { get; set; }
        public ICommand resetBoid { get; set; }
        public event Action ApplicationExit;

        public SimulationViewModel()
        {
            this.sim = new Simulation();
            timer = new TimeManagerViewModel(this);

            AddBoid = new AddBoid(this);
            resetBoid = new ResetBoidViewModel(this);

            exitCommand = new ExitCommand(this);

            speedCell = Cell.Create(100.0);
            manager = new SliderManager(this);

            this.sim.Species[0].CreateBoid(new Vector2D(50, 50));
            this.sim.Species[1].CreateBoid(new Vector2D(150, 150));

        }

        private class ExitCommand : ICommand
        {
            private SimulationViewModel simVM;

            public ExitCommand(SimulationViewModel simVM)
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
                simVM.ApplicationExit?.Invoke();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
