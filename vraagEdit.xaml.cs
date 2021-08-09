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
    /// Interaction logic for vraagEdit.xaml
    /// </summary>
    public partial class vraagEdit : Window
    {
        vraag vraag = new vraag();
        public vraagEdit(Int32 ID)
        {
            InitializeComponent();
            vraag.Read(ID);
            btnSave.Click += BtnSave_Click;

            ID = vraag.ID;
            Vraag.Text = vraag.Vraag;
            Image.Text = vraag.image;
            AntwoordA.Text = vraag.AntwoordA;
            AntwoordB.Text = vraag.AntwoordB;
            AntwoordC.Text = vraag.AntwoordC;
            AntwoordD.Text = vraag.AntwoordD;
            GoedAntwoord.Text = vraag.GoedAntwoord;
            Tijd.Text = vraag.Timer.ToString();
            
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            vraag.Update(vraag.ID, Vraag.Text.ToString(), Image.Text.ToString(), AntwoordA.Text.ToString(), AntwoordB.Text.ToString(), AntwoordC.Text.ToString(), AntwoordD.Text.ToString(), GoedAntwoord.Text.ToString(), Tijd.Text.ToString());
            MainWindow window = new MainWindow();
            this.Close();
        }

    }
}
