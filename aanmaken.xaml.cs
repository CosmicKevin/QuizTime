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
        List<QuizData> quizDataRows = new List<QuizData>();
        
        public aanmaken()
        {
            InitializeComponent();
            Next.Content = "Aanmaken";

            Next.Click += Next_Click;
            Cancel.Click += Cancel_Click;
            Save.Click += Save_Click;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            var quizData = new QuizData
            {
                Vraag = titelvdvraag.Text,
                AntwoordA = anta.Text,
                AntwoordB = antb.Text,
                AntwoordC = antc.Text,
                AntwoordD = antd.Text,
                GoedAntwoord = Goede.Text,
                Image = imgpath.Text,
                QuizNaam = quiznaam.Text,
                Timer = Convert.ToInt32(seconden.Text)
            };

            quizDataRows.Add(quizData);

            titelvdvraag.Text = null;
            anta.Text = null;
            antb.Text = null;
            antc.Text = null;
            antd.Text = null;
            seconden.Text = "30";
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.EditMode == quiz.EditModes.Add)
            {
                quiz.CreateQuiz(quizDataRows[0].QuizNaam);
                quiz.CreateVragen(quizDataRows);
            }
            else
            {
                /*quiz.Update();*/
                MessageBox.Show("Ik ga updaten");
            }
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
