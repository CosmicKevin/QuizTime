﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuizTime
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        quiz quiz = new quiz();
        public MainWindow()
        {
            InitializeComponent();

            dgQuizes.DataContext = quiz.GetData();

            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            aanmaken window = new aanmaken();
            window.Show();
            this.Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgQuizes.SelectedItem;
                int Quiz_ID = int.Parse((dgQuizes.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                aanmaken window = new aanmaken(Quiz_ID);
                window.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = dgQuizes.SelectedItem;
                int Quiz_ID = int.Parse((dgQuizes.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

                if (quiz.Delete(Quiz_ID) == true)
                {
                    dgQuizes.DataContext = quiz.GetData();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            spelen game = new spelen();
            spelenbedienen bediening = new spelenbedienen();
            Screen s1 = Screen.AllScreens[1];
            System.Drawing.Rectangle r1 = s1.WorkingArea;
            game.Top = r1.Top;
            game.Left = r1.Left;

            game.Show();
            bediening.Show();
            this.Close();
        }
    }
}
