using ProjeTakipUygulamasi.Models.MyDataBase;

namespace ProjeTakipUygulamasi.Models
{
    public class GorevYardimcisi
    {
        public int GorevId { get; set; }
        public int GorevNotuSayisi { get; set; }
        public int AltGorevSayisi { get; set; }
        public GorevYardimcisi(Gorev veri)
        {
            GorevId = veri.Id;
            GorevNotuSayisi = veri.GorevNots.Count;
            AltGorevSayisi=veri.AltGorevs.Count;
        }
    }
}
