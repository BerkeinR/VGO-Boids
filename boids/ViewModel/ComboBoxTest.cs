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

namespace ViewModel
{
    public class ComboBoxTest : INotifyPropertyChanged
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

        public ObservableCollection<IParameter> parameters { get; set; }

        public ComboBoxTest(SimulationViewModel simulationvm)
        {
            FirstComboValues = new ObservableCollection<BoidSpecies>(simulationvm.sim.Species);
            this.simulationvm = simulationvm;
            m_FirstComboValues = new ObservableCollection<BoidSpecies>(simulationvm.sim.Species);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            Console.WriteLine(propertyName);
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateParameterSliders(String type)
        {
            if(type.Equals("Model.Species.HunterSpecies"))
            {
                var bindings = simulationvm.sim.Species.First().Bindings;
                var pars = bindings.Parameters;
                
                parameters = new ObservableCollection<IParameter>(pars);
            }
        }
    }
}
