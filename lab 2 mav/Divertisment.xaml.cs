using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
using System.Collections.Generic;

namespace lab_2_mav
{
    /// <summary>
    /// Interaction logic for Divertisment.xaml
    /// </summary>
    public partial class Divertisment : Window
    {
        List<Informatii> lista = new List<Informatii>();
        int Kword=0;
        int Guesses = 0;


        public Divertisment(object dContext)
        {
            InitializeComponent();

            DataContext = dContext;
            List<int> numbers = new List<int>();
            Random rand = new Random();

            if((DataContext as InformatiiList).informatii.Count<5)
            {
                MessageBox.Show("Nu sunt suficiente cuvinte pentru a juca acest joc!");
                this.Close();
                return;
            }
            while (numbers.Count < 5)
            {
                for (int i = 1; i <= (DataContext as InformatiiList).informatii.Count; i++)
                {

                    int k = (rand.Next(i + 1)) % (DataContext as InformatiiList).informatii.Count;
                    if (!numbers.Contains(k))
                    {
                        numbers.Add(k);
                        lista.Add((DataContext as InformatiiList).informatii[k]);
                    }

                }
            }
            if (lista[Kword].linkPoza != null)
            {
                int randomNumber = rand.Next(0, 1);
                if(randomNumber == 0)
                {
                    Poza.Source = new BitmapImage(new Uri(lista[Kword].linkPoza));
                }
                else
                {
                    Descriere.Text = lista[Kword].Descriere;
                }
            }
            else Descriere.Text = lista[Kword].Descriere;
            Kword++;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (Cuvant.Text == lista[Kword-1].Cuvant)
            {
                MessageBox.Show("Corect!");
                Guesses++;
                Cuvant.Text = "";
                Descriere.Text = "";
                Poza.Source = null;
            }
            else
            {
                MessageBox.Show("Gresit! Cuvantul corect era: " + lista[Kword-1].Cuvant);
                Cuvant.Text = "";
                Descriere.Text = "";
                Poza.Source = null;
            }

            if (Kword == 5)
            {
                MessageBox.Show("Ai ghicit " + Guesses + " cuvinte!");
                return;
            }
            else
            {

                if (lista[Kword].linkPoza != null)
                {
                    Random rand = new Random();
                    int randomNumber = rand.Next(0, 1);
                    if (randomNumber == 0)
                    {
                        Poza.Source = new BitmapImage(new Uri(lista[Kword].linkPoza));
                    }
                    else
                    {
                        Descriere.Text = lista[Kword].Descriere;
                    }
                }
                else Descriere.Text = lista[Kword].Descriere;
                Kword++;
            }
        }
       
    }
}
