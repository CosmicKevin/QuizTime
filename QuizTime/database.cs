using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace QuizTime
{
    class database
    {
        private string _ConnecDB = "server=localhost;userid=KvE;password=;database=quiztime";

         public MySqlDataReader SelectQuiz()
        {
            MySqlConnection dvDBConnect = new MySqlConnection(_ConnecDB);
            dvDBConnect.Open();
            var sql = "SELECT ID FROM `quiz`";
            MySqlCommand cmd = new MySqlCommand(sql, dvDBConnect);
            return cmd.ExecuteReader(); 
        }
    }
}
