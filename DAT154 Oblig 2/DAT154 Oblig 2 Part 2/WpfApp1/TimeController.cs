using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;

namespace WpfApp1
{
    public class MyTickArgs
    {
        public int Time { get; }
        public MyTickArgs(int time)
        {
            this.Time = time;
        }
    }
    class TimeController
    {
        private int counter;
        private DispatcherTimer timer;
        public delegate void myTick(object sender, MyTickArgs e);
        public event myTick MYTICK;

        public TimeController()
        {
            this.counter = -1;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            this.counter++;
            MYTICK?.Invoke(sender, new MyTickArgs(counter));
        }
    }
}
