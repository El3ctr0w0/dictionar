using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_mav
{
    class InformatiiList
    {
        public ObservableCollection<Informatii> informatii { get; set; }
        
        
        public List<string> categorii;
        public List<string> Categorii
        {
            get
            {
                return categorii;
            }
            set
            {
                categorii = value;
            }
        }
        public InformatiiList()
        {
            informatii = new ObservableCollection<Informatii>();
        }
        
    }
}
