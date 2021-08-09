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
    /// Interaction logic for quizEdit.xaml
    /// </summary>
    public partial class quizEdit : Window
    {
        quiz quiz = new quiz();
        int quiz_ID;
        public quizEdit(Int32 Quiz_ID)
        {
            InitializeComponent();
            var quizData = quiz.Read(Quiz_ID);
            btnSave.Click += BtnSave_Click;

            quiz_ID = Quiz_ID;
            quizNaam.Text = quizData[0].QuizNaam;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            quiz.Update(quiz_ID, quizNaam.Text);
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }
    }
}
