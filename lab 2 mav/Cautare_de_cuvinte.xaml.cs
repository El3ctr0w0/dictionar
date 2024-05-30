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

namespace lab_2_mav
{
    /// <summary>
    /// Interaction logic for Cautare_de_cuvinte.xaml
    /// </summary>
    public partial class Cautare_de_cuvinte : Window
    {
        bool firstRun = true;
        public Cautare_de_cuvinte(object dContext)
        {
            DataContext = dContext;
            InitializeComponent();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = Cuvantul.Text;
            List<string> suggestions = GetSuggestions(searchText,firstRun);
            if(firstRun)
            {
                firstRun = false;
                return;
            }
            else lista.Items.Clear();
            foreach (string suggestion in suggestions)
            {
                    lista.Items.Add(suggestion);
            }
            
        }

        List<string> GetSuggestions(string searchText , bool firstrun)
        {
            if(firstrun)
            {
                return new List<string>();
            }
            List<string> suggestions = new List<string>();
            for (int i = 0; i < (DataContext as InformatiiList).informatii.Count; i++)
            {
                if((DataContext as InformatiiList).informatii[i].Categorie== Categoria.Text || Categoria.Text=="-" || Categoria.Text=="")
                 if ((DataContext as InformatiiList).informatii[i].Cuvant.Contains(searchText))
                 {
                    suggestions.Add((DataContext as InformatiiList).informatii[i].Cuvant);
                 }
            }
            return suggestions;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            imagine.Source = null;
            textBox1.Text = "";

            if(Categoria.Text!="-")
            for(int i=0; i<(DataContext as InformatiiList).informatii.Count;i++)
            {                 
                if((DataContext as InformatiiList).informatii[i].Cuvant==Cuvantul.Text && (DataContext as InformatiiList).informatii[i].Categorie==Categoria.Text)
                {
                    textBox1.Text = (DataContext as InformatiiList).informatii[i].Descriere;
                    if((DataContext as InformatiiList).informatii[i].linkPoza!=null)
                        {
                        BitmapImage bi = new BitmapImage();
                        bi.BeginInit();
                        bi.UriSource = new Uri((DataContext as InformatiiList).informatii[i].linkPoza, UriKind.Absolute);
                        bi.EndInit();
                        imagine.Source = bi;
                    }
                    return;
                }
            }
            else
            {
                for (int i = 0; i < (DataContext as InformatiiList).informatii.Count; i++)
                {
                    if ((DataContext as InformatiiList).informatii[i].Cuvant == Cuvantul.Text)
                    {
                        textBox1.Text = (DataContext as InformatiiList).informatii[i].Descriere;
                        if ((DataContext as InformatiiList).informatii[i].linkPoza != null)
                        {
                            BitmapImage bi = new BitmapImage();
                            bi.BeginInit();
                            bi.UriSource = new Uri((DataContext as InformatiiList).informatii[i].linkPoza, UriKind.Absolute);
                            bi.EndInit();
                            imagine.Source = bi;
                        }
                        return;
                    }
                }
            }
            textBox1.Text = "Cuvantul nu exista";
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                string s = lista.SelectedItem.ToString();
                Cuvantul.Text = s;
            }
        }
    }
}
