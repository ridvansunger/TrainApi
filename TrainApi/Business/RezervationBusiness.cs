using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainApi.Business
{
    using Models;

    public class RezervationBusiness
    {
        private RezervasyonBiletResponse _rezervasyonBiletResponse;
        public RezervasyonBilet _rezervasyonBilet { get; set; }
        public RezervationBusiness(RezervasyonBilet rezervasyonBilet)
        {
            _rezervasyonBilet = rezervasyonBilet;
            _rezervasyonBiletResponse = new RezervasyonBiletResponse();
        }


        public RezervasyonBiletResponse Rezervation()
        {
            if (_rezervasyonBilet.KisilerFarkliVagonlaraYerlestirilebilir)
            {
                _rezervasyonBiletResponse.RezervasyonYapilabilir = RezervationPartial();
            }
            else
            {
                _rezervasyonBiletResponse.RezervasyonYapilabilir = RezervationNotPartial();
            }
            return _rezervasyonBiletResponse;
        }

        /// <summary>
        /// Parçalı Yerleştirme
        /// </summary>
        private bool RezervationPartial()
        {
            bool result = false;

            int yerlestirilecekKisiSayisi = _rezervasyonBilet.RezervasyonYapilacakKisiSayisi;
            int trenDoldurulabilirKoltukSayisi = 0;
            foreach (var vagonItem in _rezervasyonBilet.Tren.Vagonlar)
            {
                trenDoldurulabilirKoltukSayisi += vagonItem.DoldurulabilirKoltukHesapla();
            }

            if(trenDoldurulabilirKoltukSayisi < yerlestirilecekKisiSayisi)
                result =false;
            else
            {
                int kalanRezarvasyonSayisi = _rezervasyonBilet.RezervasyonYapilacakKisiSayisi;
                foreach (var vagonItem in _rezervasyonBilet.Tren.Vagonlar)
                {
                    int doldurulabilirKoltukSayisi = vagonItem.DoldurulabilirKoltukHesapla();
                    if (doldurulabilirKoltukSayisi<=kalanRezarvasyonSayisi) //vagonun tamamı doluyor ise
                    {
                        kalanRezarvasyonSayisi -= doldurulabilirKoltukSayisi;
                        if(kalanRezarvasyonSayisi>=0)
                        {
                            _rezervasyonBiletResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = doldurulabilirKoltukSayisi, VagonAdi = vagonItem.Ad });
                            result = true;
                        }
                    }
                    else
                    {
                        _rezervasyonBiletResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = kalanRezarvasyonSayisi, VagonAdi = vagonItem.Ad });
                        //result = true;
                    }
                }
            }
            return result;
        }

    

        /// <summary>
        /// Tek Vagon Yerleştirme
        /// </summary>
        private bool RezervationNotPartial()
        {
            bool result = false;
            int yerlestirilecekKisiSayisi = _rezervasyonBilet.RezervasyonYapilacakKisiSayisi;
            foreach (var vagonItem in _rezervasyonBilet.Tren.Vagonlar)
            {
                if (vagonItem.KapasiteKontrol(yerlestirilecekKisiSayisi))
                {
                    _rezervasyonBiletResponse.YerlesimAyrinti.Add(new YerlesimAyrinti() { KisiSayisi = yerlestirilecekKisiSayisi, VagonAdi = vagonItem.Ad });
                    result = true;
                    break;
                }

            }
            return result;
        }

    }
}
