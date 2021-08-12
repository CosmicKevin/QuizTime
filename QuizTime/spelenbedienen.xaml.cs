using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Forms;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for spelenbedienen.xaml
    /// </summary>
    public partial class spelenbedienen : Window
    {
        private spelen game;
        private MainWindow window;
        private List<QuizData> quizData;
        private int currentIndex = 0;

        public spelenbedienen(int Quiz_ID)
        {
            InitializeComponent();

            game = new spelen();

            game.TimerReady += Game_TimerReady;
            Screen s1 = Screen.AllScreens[0];
            System.Drawing.Rectangle r1 = s1.WorkingArea;
            game.Top = r1.Top;
            game.Left = r1.Left;

            game.Show();
            GetQuiz(Quiz_ID);
            LoadAntwoorden();

            Volgende.Click += Volgende_Click;
            Vorige.Click += Vorige_Click;
            Aflsuiten.Click += Aflsuiten_Click;
            Nakijken.Click += Nakijken_Click;
        }

        private void Nakijken_Click(object sender, RoutedEventArgs e)
        {
            game.ToonGoedAntwoord(quizData[currentIndex].GoedAntwoord);
        }

        private void Game_TimerReady(object sender, EventArgs e)
        {
            if (currentIndex < quizData.Count - 1)
            {
                currentIndex++;
            }
            LoadAntwoorden();
        }

        private void Vorige_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
            }
            LoadAntwoorden();
        }

        private void Volgende_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex < quizData.Count - 1)
            {
                currentIndex++;
            }
            LoadAntwoorden();
        }

        private void LoadAntwoorden()
        {
            var antwoorden = quizData[currentIndex];

            var antwoord = new Antwoord(antwoorden.Vraag, antwoorden.AntwoordA, antwoorden.AntwoordB, antwoorden.AntwoordC, antwoorden.AntwoordD, antwoorden.Image, antwoorden.Timer);
            game.LoadAntwoorden(antwoord);
        }

        private void GetQuiz(int Quiz_ID)
        {
            var quiz = new quiz();
            quizData = quiz.Read(Quiz_ID);
        }

        private void Aflsuiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            window = new MainWindow();
            window.Show();
            game.AfSluiten();
        }
    }
}
