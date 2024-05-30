using System.Text;
using System.Windows;
using System.IO;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab_2_mav
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StreamReader sr = new StreamReader("C:\\Csharp\\Input_Poze.txt");

            InformatiiList informatiiList = new InformatiiList();
            List<string> categorii = new List<string>();
            string nrCuvin = sr.ReadLine();
            int nrCuv = int.Parse(nrCuvin);

            for (int i = 0; i < nrCuv; i++)
            {
                Informatii informatii = new Informatii();
                informatii.Cuvant = sr.ReadLine();
                informatii.Descriere = sr.ReadLine();
                if (informatii.Descriere == "Link")
                {
                    informatii.LinkPoza = sr.ReadLine();
                    informatii.Descriere = sr.ReadLine();
                }
                informatii.Categorie = sr.ReadLine();
                informatiiList.informatii.Add(informatii);

            }
            nrCuvin = sr.ReadLine();
            int nrCateg = int.Parse(nrCuvin);
            for (int i = 0; i < nrCateg; i++)
            {
                string s = sr.ReadLine();
                categorii.Add(s);
            }
            informatiiList.Categorii = categorii;

            DataContext = informatiiList;
            sr.Close();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {

            Cautare_de_cuvinte cautare_de_cuvinte = new Cautare_de_cuvinte(this.DataContext);
            cautare_de_cuvinte.Show();
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login(this.DataContext);
            login.Show();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {
            Divertisment divertisment = new Divertisment(this.DataContext);
            divertisment.Show();
        }
    }
}