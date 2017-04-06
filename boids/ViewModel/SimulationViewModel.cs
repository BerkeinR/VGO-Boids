﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Mathematics;
using System.ComponentModel;

namespace ViewModel
{
    public class SimulationViewModel : INotifyPropertyChanged
    {

        private Simulation sim;

        public Simulation Sim
        {
            get
            {
                return sim;
            }
            set
            {
                sim = value;
            }
        }

        public SimulationViewModel()
        {
            this.sim = new Simulation();
            this.sim.Species[0].CreateBoid(new Vector2D(50, 50));
            this.sim.Species[1].CreateBoid(new Vector2D(150, 150));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}