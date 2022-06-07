using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApi.Models
{
    public class RezervasyonBiletResponse
    {
        public RezervasyonBiletResponse()
        {
            YerlesimAyrinti = new List<YerlesimAyrinti>();
        }
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
}
