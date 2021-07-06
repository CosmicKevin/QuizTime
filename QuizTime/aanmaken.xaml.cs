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
        private List<List<quiz>> listVragen = new List<List<quiz>>();
        public aanmaken()
        {
            InitializeComponent();
            Next.Content = "Aanmaken";

            Next.Click += Next_Click;
            Cancel.Click += Cancel_Click;
            Save.Click += Save_Click;
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

            int index = 0;
            switch (quiz.GoedAntwoord)
            {
                case "AntwoordA":
                    index = 0;
                    break;

                case "AntwoordB":
                    index = 1;
                    break;

                case "AntwoordC":
                    index = 2;
                    break;

                case "AntwoordD":
                    index = 3;
                    break;
            }
            Goede.SelectedIndex = index;

            Next.Click += Next_Click;
            Cancel.Click += Cancel_Click;
            Save.Click += Save_Click;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            List<quiz> question = new List<quiz>
            {
                        new quiz
                        {
                            Vraag = titelvdvraag.Text,
                            AntwoordA = anta.Text,
                            AntwoordB = antb.Text,
                            AntwoordC = antc.Text,
                            AntwoordD = antd.Text,
                            GoedAntwoord = Goede.Text,
                            image = imgpath.Text,
                            QuizNaam = quiznaam.Text,
                            Timer = Convert.ToInt32(seconden.Text)
                        },
                    };
            listVragen.Add(question);

            titelvdvraag.Text = null;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listVragen.Count; i++)
            {
                quiz.Create(
                    
                    listVragen[i][0].Vraag, listVragen[i][0].image, listVragen[i][0].AntwoordA, listVragen[i][0].AntwoordB, listVragen[i][0].AntwoordC, listVragen[i][0].AntwoordD, listVragen[i][0].GoedAntwoord, listVragen[i][0].Timer.ToString(), listVragen[i][0].QuizNaam);
            }

        }
    }
}
