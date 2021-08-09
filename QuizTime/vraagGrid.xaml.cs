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
    /// Interaction logic for vraagGrid.xaml
    /// </summary>
    public partial class vraagGrid : Window
    {
        vraag vraag = new vraag();
        public vraagGrid(Int32 Quiz_ID)
        {
            InitializeComponent();
            dgVragen.DataContext = vraag.GetData(Quiz_ID);
            btnTerug.Click += btnTerug_Click;

        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgVragen.SelectedItem;
                int ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);
                vraagEdit window = new vraagEdit(ID);
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgVragen.SelectedItem;
                Int32 ID = int.Parse((dgVragen.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (vraag.Delete(ID) == true)
                {
                    dgVragen.DataContext = vraag.GetData(ID);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnTerug_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();

            window.Show();
            this.Close();
        }
    }
}
