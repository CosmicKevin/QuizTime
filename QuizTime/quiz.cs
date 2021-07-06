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
        private Int32 _hoeveelheidvragen;

        private string _Image;
        private string _Vraag;
        private string _AntwoordA;
        private string _AntwoordB;
        private string _AntwoordC;
        private string _AntwoordD;
        private string _GoedAntwoord;
        private Int32 _Timer;

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
        public Int32 hoeveelvragen
        {
            get { return _hoeveelheidvragen; }
            set { _hoeveelheidvragen = value; }
        }

        public string image
        {
            get { return _Image; }
            set { _Image = value; }
        }
        public string Vraag
        {
            get { return _Vraag; }
            set { _Vraag = value; }
        }
        public string AntwoordA
        {
            get { return _AntwoordA; }
            set { _AntwoordA = value; }
        }
        public string AntwoordB
        {
            get { return _AntwoordB; }
            set { _AntwoordB = value; }
        }
        public string AntwoordC
        {
            get { return _AntwoordC; }
            set { _AntwoordC = value; }
        }
        public string AntwoordD
        {
            get { return _AntwoordD; }
            set { _AntwoordD = value; }
        }
        public string GoedAntwoord
        {
            get { return _GoedAntwoord; }
            set { _GoedAntwoord = value; }
        }
        public Int32 Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }

        database sql = new database();

        public DataSet GetData()
        {
            string SQL = "SELECT * FROM quiztime.quiz";

            return sql.GetDataSet(SQL);
        }

        public void Create(string titelvdvraag, string Image, string AntwoordA, string AntwoordB, string AntwoordC, string AntwoordD, string GoedAntwoord, string Timer, string QuizNaam)
        {
            string SQL = string.Format("INSERT INTO quiztime.vraag (Vraag, Image, AntwoordA, AntwoordB, AntwoordC, AntwoordD, GoedAntwoord, Timer) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                         titelvdvraag, Image, AntwoordA, AntwoordB, AntwoordC, AntwoordD, GoedAntwoord, Timer);

            string SQLQ = string.Format("INSERT INTO quiztime.quiz (quiznaam) VALUES ('{0}')", QuizNaam);
            sql.ExecuteNonQuery(SQL);
            sql.ExecuteNonQuery(SQLQ);
        }
        public void Read(Int32 Quiz_ID)
        {
            string SQL = string.Format("SELECT vraag.Vraag, vraag.Image, vraag.AntwoordA, vraag.AntwoordB, vraag.AntwoordC, vraag.AntwoordD, vraag.GoedAntwoord, vraag.Timer, vraag.Quiz_ID, quiz.QuizNaam FROM vraag INNER JOIN quiz ON vraag.Quiz_ID = quiz.ID WHERE Quiz_ID = {0}", Quiz_ID);
            DataTable datatable = sql.GetDataTable(SQL);
            _Quiz_ID = Convert.ToInt32(datatable.Rows[0]["Quiz_ID"].ToString());
            _Vraag = datatable.Rows[0]["Vraag"].ToString();
            _Image = datatable.Rows[0]["Image"].ToString();
            _AntwoordA = datatable.Rows[0]["AntwoordA"].ToString();
            _AntwoordB = datatable.Rows[0]["AntwoordB"].ToString();
            _AntwoordC = datatable.Rows[0]["AntwoordC"].ToString();
            _AntwoordD = datatable.Rows[0]["AntwoordD"].ToString();
            _GoedAntwoord = datatable.Rows[0]["GoedAntwoord"].ToString();
            _Timer = Convert.ToInt32(datatable.Rows[0]["Timer"].ToString());
            _QuizNaam = datatable.Rows[0]["QuizNaam"].ToString();
        }
        public void Update(Int32 Quiz_ID, string titelvdvraag, string Image, string AntwoordA, string AntwoordB, string AntwoordC, string AntwoordD, string GoedAntwoord, string Timer, string QuizNaam)
        {
            string SQL = string.Format("UPDATE quiztime.vraag " +
                                        "Set Vraag          = '{0}', " +
                                        "Image              = '{1}', " +
                                        "AntwoordA          = '{2}', " +
                                        "AntwoordB          = '{3}', " +
                                        "AntwoordC          = '{4}', " +
                                        "AntwoordD          = '{5}', " +
                                        "GoedAntwoord       = '{6}', " +
                                        "Timer              = '{7}', " +
                                        "QuizNaam           = '{8}', " +
                                        "WHERE QuizID       = '{9}'", titelvdvraag,
                                                                      Image,
                                                                      AntwoordA,
                                                                      AntwoordB,
                                                                      AntwoordC,
                                                                      AntwoordD,
                                                                      GoedAntwoord,
                                                                      Timer,
                                                                      QuizNaam,
                                                                      Quiz_ID);
            sql.ExecuteNonQuery(SQL);
        }
        public bool Delete(Int32 Quiz_ID)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Wilt u deze quiz verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM quiztime.vraag WHERE Quiz_ID = {0}", Quiz_ID);
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
