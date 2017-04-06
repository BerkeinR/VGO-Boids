using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using System.Windows.Threading;

namespace View
{
    public class TimerService : ITimerService
    {
        public TimerService()
        {
            _timer = new DispatcherTimer();
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Tick?.Invoke(this);
        }

        public void Start(TimeSpan interval)
        {
            _timer.Interval = interval;
            if (!_timer.IsEnabled)
            {
                _timer.Start();
            }
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public event Action<ITimerService> Tick;
        private DispatcherTimer _timer;
    }
}
