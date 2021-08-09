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
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
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
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
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
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public int ExecuteGetRowId()
        {
            int rowId = -1;
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", conn);
                rowId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (MySqlException ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
            return rowId;
        }

    }
}
