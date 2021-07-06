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
using System.Windows.Shapes;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for spelenbedienen.xaml
    /// </summary>
    public partial class spelenbedienen : Window
    {
        private spelen game;
        private MainWindow window;
        public spelenbedienen(int Quiz_ID)
        {
            InitializeComponent();
            game = new spelen(Quiz_ID);

            Screen s1 = Screen.AllScreens[0];
            System.Drawing.Rectangle r1 = s1.WorkingArea;
            game.Top = r1.Top;
            game.Left = r1.Left;

            game.Show();
            Aflsuiten.Click += Aflsuiten_Click;
        }

        private void Aflsuiten_Click(object sender, RoutedEventArgs e)
        {
            window = new MainWindow();
            window.Show();
            game.Close();
            this.Close();
        }
    }
}
