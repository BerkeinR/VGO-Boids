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
        public Cell<double> speedCell { get; set; }
        public ComboBoxTest boxTest { get; set; }

        public SimulationViewModel()
        {
            this.sim = new Simulation();

            AddBoid = new AddBoid(this);
            speedCell = Cell.Create(100.0);
            boxTest = new ComboBoxTest(this);

            this.sim.Species[0].CreateBoid(new Vector2D(50, 50));
            this.sim.Species[1].CreateBoid(new Vector2D(150, 150));

            var timer = ServiceLocator.Current.GetInstance<ITimerService>();
            timer.Tick += Timer_Tick;
            timer.Start(new TimeSpan(0, 0, 0, 0, 15));

          //var bindings = sim.Species.First().Bindings;
            //var pars = bindings.Parameters;
            //var speed  = pars.Where(c => c.Id == "Maximum speed").Single();
            //var rangedDoubleSpeed = speed as RangedDoubleParameter;
            //var value = bindings.Read(rangedDoubleSpeed);
            //value.Value = speedCell.Value;
        }

        private void Timer_Tick(ITimerService obj)
        {

            sim.Update(0.01);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
