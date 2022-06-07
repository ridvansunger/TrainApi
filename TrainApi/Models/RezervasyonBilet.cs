using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApi.Models
{
    public class RezervasyonBilet
    {
        public Tren Tren { get; set; }
        public int RezervasyonYapilacakKisiSayisi { get; set; }
        public bool KisilerFarkliVagonlaraYerlestirilebilir { get; set; }
    }

    
}
