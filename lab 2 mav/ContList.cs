using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2_mav
{
    public class ContList
    {
        public ObservableCollection<Cont> conturi { get; set; }

        
        public ContList()
        {
            conturi = new ObservableCollection<Cont>();
        }
    }
}
