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
    /// Interaction logic for Administrativ.xaml
    /// </summary>
    public partial class Administrativ : Window
    {
        public Administrativ(object dContext)
        {
            InitializeComponent();
            DataContext = dContext;

            for(int i=0 ; i<(DataContext as InformatiiList).Categorii.Count;i++ )
            {
                ComboBox.Items.Add((DataContext as InformatiiList).Categorii[i]);
            }
        }

        public void button_Click(object sender, RoutedEventArgs e)
        {
            Informatii informatii = new Informatii() { Cuvant=Cuvantul.Text , Descriere= Definitia.Text , Categorie=Categoria.Text };
            bool categorieExistenta = false;

            if(Cuvantul.Text=="" || Definitia.Text=="" || Categoria.Text=="")
            {
                MessageBox.Show("Completati toate campurile!!");
                return;
            }
            if(Categoria.Text== "Introduce categoria" || Definitia.Text== "Introduce definitia" || Cuvantul.Text== "Introduce cuvantul")
            {
                MessageBox.Show("Introduceti informatii valide!");
                return;
            }

            for(int i=0;i< (DataContext as InformatiiList).informatii.Count;i++)
            {
                if((DataContext as InformatiiList).informatii[i].Cuvant==Cuvantul.Text)
                {
                    MessageBox.Show("Cuvantul exista deja!!");
                    return;
                }
                if((DataContext as InformatiiList).informatii[i].Categorie==Categoria.Text)
                {
                    categorieExistenta = true;
                }
            }
            if(LinkPoza.Text!="" && LinkPoza.Text!="Link Poza")
            {
                informatii.LinkPoza = LinkPoza.Text;
            }

            (DataContext as InformatiiList).informatii.Add(informatii);
            MessageBox.Show("Informatii adaugate!!");

            if(categorieExistenta==false)
            {
                (DataContext as InformatiiList).Categorii.Add(Categoria.Text);
                ComboBox.Items.Add(Categoria.Text);
            }
            
        }
        public void button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < (DataContext as InformatiiList).informatii.Count; i++)
                if ((DataContext as InformatiiList).informatii[i].Cuvant == Cuvantul.Text && (DataContext as InformatiiList).informatii[i].Categorie==Categoria.Text)
                {
                    (DataContext as InformatiiList).informatii.RemoveAt(i);
                    MessageBox.Show("Informatii sterse");
                    return;
                }
            MessageBox.Show("Cuvantul nu exista in aceasta categorie");
        }
        public void button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < (DataContext as InformatiiList).informatii.Count; i++)
                if ((DataContext as InformatiiList).informatii[i].Cuvant == Cuvantul.Text && (DataContext as InformatiiList).informatii[i].Categorie==Categoria.Text)
                {
                    (DataContext as InformatiiList).informatii[i].Descriere = Definitia.Text;
                    if (LinkPoza.Text != "" && LinkPoza.Text != "Link Poza")
                    {
                        (DataContext as InformatiiList).informatii[i].LinkPoza = LinkPoza.Text;
                    }
                    MessageBox.Show("Informatii modificate");
                    return;
                }
            MessageBox.Show("Cuvantul nu exista in aceasta categorie");
        }

        private void Selecteaza_Click(object sender, RoutedEventArgs e)
        {
            Categoria.Text = ComboBox.Text;
        }
    }
}
