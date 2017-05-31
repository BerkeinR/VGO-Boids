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
using Microsoft.Practices.ServiceLocation;
using System.Media;
using System.IO;

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
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            base.OnStartup(e);
            var main = new MainWindow();
            var vm = new SimulationViewModel();
            vm.ApplicationExit += ExitCommand_ApplicationExit;
            main.DataContext = vm;
            main.Show();
            Play();

        }
          private readonly SoundPlayer player = new SoundPlayer(View.Properties.Resources.music);

        public void Play()
        {
            player.Play();
        }

        private void ExitCommand_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
    }
}