using System;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
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
        private Timer timer;
        public spelen()
        {
            InitializeComponent();
        }
        public void LoadAntwoorden(Antwoord antwoord)
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
            }

            txbanta.Background = Brushes.Yellow;
            antb.Background = Brushes.Yellow;
            antc.Background = Brushes.Yellow;
            antd.Background = Brushes.Yellow;

            txbanta.Text = antwoord.AntwoordA;
            antb.Text = antwoord.AntwoordB;
            antc.Text = antwoord.AntwoordC;
            antd.Text = antwoord.AntwoordD;
            titel.Text = antwoord.Vraag;
            tijd.Content = antwoord.Tijd;

            try
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(antwoord.Image);
                bitmap.EndInit();
                plaatje.Source = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is geen plaatje: " + ex.Message);
            }
            time = Convert.ToInt32(tijd.Content);
            timer = new Timer(new TimerCallback(TickTimer), null, 1000, 1000);

        }

        public void ToonGoedAntwoord(string antwoord)
        {
            switch (antwoord)
            {
                case "AntwoordA":
                    txbanta.Background = Brushes.Green;
                    break;
                case "AntwoordB":
                    antb.Background = Brushes.Green;
                    break;
                case "AntwoordC":
                    antc.Background = Brushes.Green;
                    break;
                case "AntwoordD":
                    antd.Background = Brushes.Green;
                    break;
                default:
                    break;
            }
        }

        public void AfSluiten()
        {
            if (timer != null)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            this.Close();
        }

        void TickTimer(object state)
        {
            UpdateTimerVeld();
        }

        private void UpdateTimerVeld()
        {
            if (!Dispatcher.CheckAccess())
            {
                // We're not in the UI thread, ask the dispatcher to call this same method in the UI thread, then exit
                Dispatcher.BeginInvoke(new Action(UpdateTimerVeld));
                return;
            }

            // We're in the UI thread, update the controls
            time--;
            tijd.Content = time;

            if (time == 0)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;

                if (TimerReady != null)
                {
                    TimerReady(this, EventArgs.Empty);
                }
            }
        }
    }
}
