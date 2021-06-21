using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
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
            
            game.Show();
            bediening.Show();
            this.Close();
        }
    }
}
