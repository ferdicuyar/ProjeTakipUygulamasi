using ProjeTakipUygulamasi.Models;
using ProjeTakipUygulamasi.Models.MyDataBase;

namespace ProjeTakipUygulamasi.Service.Interfaces
{
    public interface IGenelService
    {
        Kullanici LoginKontrol(Kullanici veri);
        List<Proje> TumProjeler();
        decimal ProjeButcesi(int projeId);
        void ProjeBilgileri(int projeId, out int gorevSayisi, out int notSayisi);
        List<Gorev> GorevleriGetir(int projeId, out List<GorevYardimcisi> GorevBilgileri);
        void GoreviBitir(Gorev gorev);
        List<GorevKategori> KategorileriGetir();
        List<Kullanici> KullanicilariGetir();
        void GorevKayit(Gorev veri);
        void AltGorevKayit(AltGorev veri);
        List<AltGorev> AltGorevleriGetir(int veriId);
        void GorevNotKayit(GorevNot veri);
        List<GorevNot> GorevNotlariniGetir(int gorevId);
        List<ProjeNot> ProjeNotlariniGetir(int projeId);
        void ProjeNotKayit(ProjeNot veri);
        List<Teknoloji> TeknolojileriGetir();
        List<ProjeTeknoloji> ProjeninTeknolojileriniGetir(int projeId);
        void TeknolojiEkle(Teknoloji veri);
        void ProjeyeTeknolojiEkle(int teknolojiId, int projeId);
        void TeknolojiCikar(int projeteknolojiId);
        void KullaniciEkle(Kullanici veri);
        List<ProjeMaliyet> ButceKalemleriniGetir(int projeId);
        List<ProjeMaliyet> ButceKalemiEkleGuncelle(ProjeMaliyet veri);
        Proje YeniProjeOlustur(Proje veri);
        List<Proje> ProjeyiBitir(Proje veri);
    }
}
