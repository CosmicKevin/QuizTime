using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            maken.Click += new RoutedEventHandler(Maken_Click);
            begin.Click += new RoutedEventHandler(spelen_Click);
        }

        private void Maken_Click(object sender, RoutedEventArgs e)
        {
            aanmaken game = new aanmaken();
            game.Show();
            this.Close();
        }

        private void spelen_Click(object sender, RoutedEventArgs e)
        {
            spelen game = new spelen();
            spelenbedienen bediening = new spelenbedienen();
            Screen s1 = Screen.AllScreens[1];
            System.Drawing.Rectangle r1 = s1.WorkingArea;
            game.Top = r1.Top;
            game.Left = r1.Left;

            game.Show();
            bediening.Show();
            this.Close();
        }
    }
}
