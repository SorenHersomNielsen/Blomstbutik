using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blomstbutik
{
    public class BlomstViewModel
    {
        public ObservableCollection<Ordreblomst> OC_Blomst { get; set; }
          = new ObservableCollection<Ordreblomst>();


        public BlomstViewModel()
        {
            OC_Blomst = new ObservableCollection<Ordreblomst>();
            OC_Blomst.Add(new Ordreblomst("tulipan","Rød",2));
            OC_Blomst.Add(new Ordreblomst("tulipan", "grøn", 3));
        }

    }
}
