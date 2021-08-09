using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizTime
{
    class vraag
    {
        private string _Image;
        private string _Vraag;
        private string _AntwoordA;
        private string _AntwoordB;
        private string _AntwoordC;
        private string _AntwoordD;
        private string _GoedAntwoord;
        private Int32 _Timer;
        private Int32 _ID;

        public Int32 ID
        {
            get { return _ID; }
            set { _ID = value; }
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
        public Int32 Timer
        {
            get { return _Timer; }
            set { _Timer = value; }
        }
        public string GoedAntwoord
        {
            get { return _GoedAntwoord; }
            set { _GoedAntwoord = value; }
        }
        public DataSet GetData(Int32 Quiz_ID)
        {
            string SQL = string.Format("SELECT * FROM quiztime.vraag WHERE Quiz_ID = {0}", Quiz_ID);

            return sql.GetDataSet(SQL);
        }

        private database sql = new database();
        public void Create(string devraag, bool GoedeAntwoord, Int32 ID)
        {
            //string SQL = string.Format("INSERT INTO dbworkshop.tblanswers (omschrijving, correct) VALUES ('{0}', {1})", omschrijving, correct);



            string SQL = string.Format("INSERT INTO quiztime.vraag (Vraag, GoedeAntwoord, Quiz_ID) " +
                                       "VALUES ('{0}', {1}, (SELECT id FROM quiztime.quiz WHERE ID = {2}))", devraag, GoedeAntwoord, ID);




            sql.ExecuteNonQuery(SQL);
        }
        public void Read(Int32 ID)
        {
            string SQL = string.Format("SELECT vraag.Vraag, vraag.Image, vraag.AntwoordA, vraag.AntwoordB, vraag.AntwoordC, vraag.AntwoordD, vraag.GoedAntwoord, vraag.Timer, vraag.ID FROM vraag WHERE ID = {0}", ID);
            DataTable datatable = sql.GetDataTable(SQL);
            _ID = Convert.ToInt32(datatable.Rows[0]["ID"].ToString());
            _Vraag = datatable.Rows[0]["Vraag"].ToString();
            _Image = datatable.Rows[0]["Image"].ToString();
            _AntwoordA = datatable.Rows[0]["AntwoordA"].ToString();
            _AntwoordB = datatable.Rows[0]["AntwoordB"].ToString();
            _AntwoordC = datatable.Rows[0]["AntwoordC"].ToString();
            _AntwoordD = datatable.Rows[0]["AntwoordD"].ToString();
            _GoedAntwoord = datatable.Rows[0]["GoedAntwoord"].ToString();
            _Timer = Convert.ToInt32(datatable.Rows[0]["Timer"].ToString());
        }
        public bool Delete(Int32 ID)
        {
            bool isDeleted = false;
            if (MessageBox.Show("Wilt u deze vraag verwijderen?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                string SQL = string.Format("DELETE FROM quiztime.vraag WHERE ID = {0}", ID);

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
        public void Update(int ID, string Vraag, string Image, string AntwoordA, string AntwoordB, string AntwoordC, string AntwoordD, string GoedAntwoord, string Timer)
        {
            string SQL = string.Format("UPDATE quiztime.vraag " +
                                        "Set Vraag          = '{0}', " +
                                        "Image              = '{1}', " +
                                        "AntwoordA          = '{2}', " +
                                        "AntwoordB          = '{3}', " +
                                        "AntwoordC          = '{4}', " +
                                        "AntwoordD          = '{5}', " +
                                        "GoedAntwoord       = '{6}', " +
                                        "Timer              = {7} " +
                                        "WHERE ID       = {8}", Vraag,
                                                                      Image,
                                                                      AntwoordA,
                                                                      AntwoordB,
                                                                      AntwoordC,
                                                                      AntwoordD,
                                                                      GoedAntwoord,
                                                                      Timer,
                                                                      ID);
            sql.ExecuteNonQuery(SQL);
        }
    }
}
