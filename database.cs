using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizTime
{
    class database
    {
        MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataSet GetDataSet(string SQL)
        {
            DataSet dataset = new DataSet();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(dataset, "LoadDataBinding");
                conn.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            return dataset;
        }

        public DataTable GetDataTable(string SQL)
        {
            DataTable datatable = new DataTable();

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                adp.Fill(datatable);
                conn.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }

            return datatable;
        }

        public void ExecuteNonQuery(string SQL)
        {
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(SQL, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}
