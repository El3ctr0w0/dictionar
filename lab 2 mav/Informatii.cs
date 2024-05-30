using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_mav
{
    internal class Informatii
    {
        private string cuvant;
        public string Cuvant
        {
            get
            {
                return cuvant;
            }
            set
            {
                cuvant = value;
               // NotifyPropertyChanged("Cuvant");
            }
        }

        private string descriere;
        public string Descriere
        {
            get
            {
                return descriere;
            }
            set
            {
                descriere = value;
                //NotifyPropertyChanged("Descriere");
            }
        }

        public string categorie;
        public string Categorie
        {
            get
            {
                return categorie;
            }
            set
            {
                categorie = value;
                //NotifyPropertyChanged("Categorie");
            }
        }
        public string linkPoza= null;
        public string LinkPoza
        {
            get
            {
                return linkPoza;
            }
            set
            {
                linkPoza = value;
               // NotifyPropertyChanged("LinkPoza");
            }
        }

        //public event PropertyChangedEventHandler PropertyChanged;
        //private void NotifyPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
