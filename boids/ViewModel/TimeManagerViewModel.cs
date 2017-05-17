using Microsoft.Practices.ServiceLocation;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class TimeManagerViewModel : ICommand
    {
        private SimulationViewModel simVm;
        private Boolean paused = false;
        ITimerService timer = ServiceLocator.Current.GetInstance<ITimerService>();

        public TimeManagerViewModel(SimulationViewModel simVm)
        {
            this.simVm = simVm;
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 15));
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (paused)
            {
                timer.Start(new TimeSpan(0, 0, 0, 0, 15));
                paused = false;
            }
            else
            {
                timer.Stop();
                paused = true;
            }
        }

        private void Timer_Tick(ITimerService obj)
        {
            if(!paused)
            {
                simVm.sim.Update(0.01);
            }
            
        }

    }
}
