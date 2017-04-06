using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using Microsoft.Practices.Unity;
using Service;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var container = new UnityContainer();
            container.RegisterType<ITimerService, TimerService>();

            base.OnStartup(e);
            var main = new MainWindow();
            main.DataContext = new SimulationViewModel();
            main.Show();
        }
    }
}