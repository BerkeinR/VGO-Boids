using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model.Species;
using Bindings;
using Cells;

namespace ViewModel
{
    public class SliderManager : INotifyPropertyChanged
    {
        private SimulationViewModel simulationvm;
        protected string m_FirstSelectedValue;

        public string FirstSelectedValue
        {
            get { return m_FirstSelectedValue; }
            set
            {
                Console.WriteLine(value);
                if (m_FirstSelectedValue != value)
                {
                    m_FirstSelectedValue = value;
                    UpdateParameterSliders(value);
                    
                    NotifyPropertyChanged("FirstSelectedValue");
                }
            }
        }

        protected ObservableCollection<BoidSpecies> m_FirstComboValues;

        public ObservableCollection<BoidSpecies> FirstComboValues
        {
            get { return m_FirstComboValues; }
            set
            {
                if (m_FirstComboValues != value)
                {
                    m_FirstComboValues = value;
                    NotifyPropertyChanged("FirstComboValues");
                }
            }
        }

        public ObservableCollection<ParameterWrapper> parameters { get; set; }

        public SliderManager(SimulationViewModel simulationvm)
        {
            this.simulationvm = simulationvm;
            m_FirstComboValues = new ObservableCollection<BoidSpecies>(simulationvm.sim.Species);
            parameters = new ObservableCollection<ParameterWrapper>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateParameterSliders(String type)
        {
            var selectedSpecies = simulationvm.sim.Species.Where(s => s.Name == type).Single();

            var bindings = selectedSpecies.Bindings;
                var pars = bindings.Parameters;
                parameters.Clear();
                foreach (var data in pars)
                {
                Console.WriteLine(data);
                    if (data is RangedDoubleParameter)
                    {
                        var d = (RangedDoubleParameter)data;
                        
                        var paramContent = selectedSpecies.Bindings.Read(d);

                        parameters.Add(new ParameterWrapper(paramContent, d.Maximum, d.Minimum, d.Id));

                }
            }
        }
    }
}
