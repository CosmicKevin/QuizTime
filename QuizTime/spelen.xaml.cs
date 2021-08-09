using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for spelen.xaml
    /// </summary>
    public partial class spelen : Window
    {
        public event EventHandler TimerReady;

        private int time;
        private DispatcherTimer timer;

        public spelen()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += Timer_Tick;
        }
        public void LoadAntwoorden(Antwoord antwoord)
        {
            timer.Stop();

            anta.Text = antwoord.AntwoordA;
            antb.Text = antwoord.AntwoordB;
            antc.Text = antwoord.AntwoordC;
            antd.Text = antwoord.AntwoordD;
            titel.Text = antwoord.Vraag;
            tijd.Content = antwoord.Tijd;

            time = Convert.ToInt32(tijd.Content);

            timer.Start();

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            time--;

            tijd.Content = time.ToString();

            if (time == 0)
            {
                timer.Stop();
               
                if(TimerReady != null)
                {
                    TimerReady(this, EventArgs.Empty);
                }
            }
        }
    }
}
