using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizTime
{
    class quiz
    {
        private Int32 _Quiz_ID;
        private string _QuizNaam;

        public enum EditModes
        {
            Add,
            Edit
        };

        private static EditModes editMode;
        public EditModes EditMode
        {
            get { return editMode; }
            set { editMode = value; }
        }
        public Int32 Quiz_ID
        {
            get { return _Quiz_ID; }
            set { _Quiz_ID = value; }
        }

        public string QuizNaam
        {
            get { return _QuizNaam; }
            set { _QuizNaam = value; }
        }

        private database sql = new database();

        public DataSet GetData()
        {
            string SQL = "SELECT * FROM quiztime.quiz";

            return sql.GetDataSet(SQL);
        }

        public void CreateQuiz(string QuizNaam)
        {
            string SQLQ = string.Format("INSERT INTO quiztime.quiz (QuizNaam) VALUES ('{0}')", QuizNaam);

            sql.ExecuteNonQuery(SQLQ);
        }
        public void CreateVragen(List<QuizData> quizData)
        {
            int rowId = sql.ExecuteGetRowId();

            for (int i = 0; i < quizData.Count; i++)
            {
                string SQL = string.Format("INSERT INTO quiztime.vraag (Vraag, Image, AntwoordA, AntwoordB, AntwoordC, AntwoordD, GoedAntwoord, Timer, Quiz_ID) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8})",
                          quizData[i].Vraag, quizData[i].Image, quizData[i].AntwoordA, quizData[i].AntwoordB, quizData[i].AntwoordC, quizData[i].AntwoordD, quizData[i].GoedAntwoord, quizData[i].Timer.ToString(), rowId);
                sql.ExecuteNonQuery(SQL);
            }

        }

        public void spelen(Int32 Quiz_ID)
        {
            string SQL = string.Format("SELECT vraag.Vraag, vraag.Image, vraag.AntwoordA, vraag.AntwoordB, vraag.AntwoordC, vraag.AntwoordD, vraag.GoedAntwoord, vraag.Timer, vraag.Quiz_ID, quiz.QuizNaam FROM vraag INNER JOIN quiz ON vraag.Quiz_ID = quiz.ID WHERE Quiz_ID = {0}", Quiz_ID);

        }
        public List<QuizData> Read(Int32 Quiz_ID)
        {
            var quizDataRows = new List<QuizData>();

            string SQL = string.Format("SELECT vraag.Vraag, vraag.Image, vraag.AntwoordA, vraag.AntwoordB, vraag.AntwoordC, vraag.AntwoordD, vraag.GoedAntwoord, vraag.Timer, vraag.Quiz_ID, quiz.QuizNaam FROM vraag INNER JOIN quiz ON vraag.Quiz_ID = quiz.ID WHERE Quiz_ID = {0}", Quiz_ID);
            DataTable datatable = sql.GetDataTable(SQL);

            foreach (DataRow row in datatable.Rows)
            {
                var quizDataItem = new QuizData();
                quizDataItem.Quiz_ID = Convert.ToInt32(row["Quiz_ID"]);
                quizDataItem.Vraag = row["Vraag"].ToString();
                quizDataItem.Image = row["Image"].ToString();
                quizDataItem.AntwoordA = row["AntwoordA"].ToString();
                quizDataItem.AntwoordB = row["AntwoordB"].ToString();
                quizDataItem.AntwoordC = row["AntwoordC"].ToString();
                quizDataItem.AntwoordD = row["AntwoordD"].ToString();
                quizDataItem.GoedAntwoord = row["GoedAntwoord"].ToString();
                quizDataItem.Timer = Convert.ToInt32(row["Timer"]);
                quizDataItem.QuizNaam = row["QuizNaam"].ToString();

                quizDataRows.Add(quizDataItem);
            }

            return quizDataRows;
        }
        public void Update(Int32 Quiz_ID, string QuizNaam)
        {
            string SQL = string.Format("UPDATE quiztime.quiz " +
                                        "Set QuizNaam       = '{0}' "+
                                        "WHERE ID       = {1}", QuizNaam,
                                                                      Quiz_ID);
            sql.ExecuteNonQuery(SQL);
        }
        public bool Delete(Int32 Quiz_ID)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Wilt u deze quiz verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {

                string SQLQ = string.Format("DELETE FROM quiztime.vraag WHERE Quiz_ID = {0}", Quiz_ID);
                string SQL = string.Format("DELETE FROM quiztime.quiz WHERE ID = {0}", Quiz_ID);

                sql.ExecuteNonQuery(SQLQ);
                sql.ExecuteNonQuery(SQL);

                isDeleted = true;

                MessageBox.Show("De quiz is succesvol verwijderd");
            }
            else
            {
                MessageBox.Show("de quiz is niet verwijderd");
            }

            return isDeleted;
        }
    }
}
