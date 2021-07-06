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
using System.Windows.Shapes;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for spelen.xaml
    /// </summary>
    public partial class spelen : Window
    {
        quiz quiz = new quiz();
        public spelen(Int32 Quiz_ID)
        {
            InitializeComponent();

            quiz.Read(Quiz_ID);

            Quiz_ID = quiz.Quiz_ID;
            anta.Text = quiz.AntwoordA;
            antb.Text = quiz.AntwoordB;
            antc.Text = quiz.AntwoordC;
            antd.Text = quiz.AntwoordD;
            titel.Text = quiz.Vraag;
            tijd.Content = quiz.Timer;
        }
    }
}
