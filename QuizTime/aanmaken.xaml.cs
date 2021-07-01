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
    /// Interaction logic for aanmaken.xaml
    /// </summary>
    public partial class aanmaken : Window
    {
        quiz quiz = new quiz();
        public aanmaken()
        {
            InitializeComponent();
            Next.Content = "Aanmaken";

            Next.Click += Next_Click;
            Cancel.Click += Cancel_Click;
        }

        public aanmaken(Int32 Quiz_ID)
        {
            InitializeComponent();
            quiz.Read(Quiz_ID);

            Quiz_ID = quiz.Quiz_ID;
            titelvdvraag.Text = quiz.Vraag;
            imgpath.Text = quiz.image;
            anta.Text = quiz.AntwoordA;
            antb.Text = quiz.AntwoordB;
            antc.Text = quiz.AntwoordC;
            antd.Text = quiz.AntwoordD;
            seconden.Text = quiz.Timer.ToString();
            quiznaam.Text = quiz.QuizNaam;

            Next.Click += Next_Click;
            Cancel.Click += Cancel_Click;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
