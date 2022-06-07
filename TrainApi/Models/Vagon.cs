using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApi.Models
{
    public class Vagonlar
    {
        public string Ad { get; set; }
        public int Kapasite { get; set; }
        public int DoluKoltukAdet { get; set; }
        public bool KapasiteKontrol(decimal Sayi)
        {
            //Kapasite 70 altında ise true değil ise false
            decimal deger=Convert.ToDecimal((((DoluKoltukAdet + Sayi) / Kapasite) * 100) );
            return deger <= 70;
        }


        //vagondaki boş koltukları hesapla
        public int DoldurulabilirKoltukHesapla()
        {
            int doldurulabilirBosKoltukSayisi = Convert.ToInt32(Kapasite * 0.7m) - DoluKoltukAdet;
            return doldurulabilirBosKoltukSayisi;
        }
    }
}
