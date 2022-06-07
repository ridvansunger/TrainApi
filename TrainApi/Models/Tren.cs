using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApi.Models
{
    public class Tren
    {
        public string Ad { get; set; }
        public List<Vagonlar> Vagonlar { get; set; }
    }


}
