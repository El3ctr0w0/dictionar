using System;
using System.Collections.Generic;
using System.IO;
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

namespace lab_2_mav
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public ContList contList = new ContList();

        public Login(object dContext)
        {
            InitializeComponent();

            DataContext = dContext;

            StreamReader sr = new StreamReader("Conturi.txt");


            while(!sr.EndOfStream)
            {
                Cont cont = new Cont();
                cont.Username = sr.ReadLine();
                cont.Password = sr.ReadLine();
                contList.conturi.Add(cont);
            }
          

        }

        private void LogIN_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<contList.conturi.Count;i++)
            {
                if(contList.conturi[i].Username==Username.Text && contList.conturi[i].Password==Password.Text)
                {
                    Administrativ administrativ = new Administrativ(this.DataContext);
                    administrativ.Show();
                    this.Close();
                    return;
                }
            }
        }
    }
}
