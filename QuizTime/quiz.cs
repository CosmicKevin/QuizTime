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
        private string _naamquiz;
        private Int32 _hoeveelheidvragen;

        private string _Image;
        private Int32 _Vraag;
        private string _AntwoordA;
        private string _AntwoordB;
        private string _AntwoordC;
        private string _AntwoordD;
        private string _GoedAntwoord;
        private Int32 _Timer;

        public Int32 QuizID
        {
            get { return _Quiz_ID; }
            set { _Quiz_ID = value; }
        }
        public string naamquiz
        {
            get { return _naamquiz; }
            set { _naamquiz = value; }
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
        public Int32 Vraag
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
            string SQL = "SELECT * FROM quiztime";

            return sql.GetDataSet(SQL);
        }

        public void Create(string titelvdvraag, string Image, string AntwoordA, string AntwoordB, string AntwoordC, string AntwoordD, string GoedAntwoord, string Timer)
        {
            string SQL = string.Format("INSERT INTO quiztime.vraag (Vraag, Image, AntwoordA, AntwoordB, AntwoordC, AntwoordD, GoedAntwoord, Timer) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                         titelvdvraag, Image, AntwoordA, AntwoordB, AntwoordC, AntwoordD, GoedAntwoord, Timer);

            sql.ExecuteNonQuery(SQL);
        }
        public void Read(Int32 QuizID)
        {
            string SQL = string.Format("SELECT * WHERE QuizID = {0}", QuizID);
            DataTable datatable = sql.GetDataTable(SQL);
        }
        public void Update()
        {

        }
        public bool Delete(Int32 QuizID)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Wilt u deze quiz verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM * WHERE Quiz_ID = {0}", QuizID);
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
