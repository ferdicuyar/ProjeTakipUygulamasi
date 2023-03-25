using Microsoft.EntityFrameworkCore;
using ProjeTakipUygulamasi.Models;
using ProjeTakipUygulamasi.Models.MyDataBase;
using ProjeTakipUygulamasi.Service.Interfaces;

namespace ProjeTakipUygulamasi.Service
{
    public class GenelService : IGenelService
    {
        readonly ProjectContext db;
        public GenelService(ProjectContext _db)
        {
            db = _db;
        }
        public Kullanici LoginKontrol(Kullanici veri)
        {
            return db.Kullanicis.FirstOrDefault(x => x.KullaniciAdi == veri.KullaniciAdi && x.Sifre == veri.Sifre);
        }
        public List<Proje> TumProjeler()
        {
            return db.Projes.Include(x => x.ProjeSahibi).ToList();
        }
        public List<Proje> ProjeyiBitir(Proje veri)
        {
            veri.ProjeBittimi = true;
            db.Projes.Update(veri);
            db.SaveChanges();
            return db.Projes.Include(x => x.ProjeSahibi).ToList();
        }
        public void ProjeBilgileri(int projeId, out int gorevSayisi, out int notSayisi)
        {
            gorevSayisi=db.Gorevs.Where(x=>x.ProjeId==projeId).Count();
            notSayisi = db.ProjeNots.Where(x => x.ProjeId == projeId).Count();
        }
        public decimal ProjeButcesi(int projeId)
        {
            return db.ProjeMaliyets.Where(x => x.ProjeId == projeId&&!x.GelirGider&&!x.Vazgecildi).Sum(x => x.Tutar);
        }
        public List<Gorev> GorevleriGetir(int projeId, out List<GorevYardimcisi> GorevBilgileri)
        {
            List<Gorev> data= db.Gorevs.Where(x => x.ProjeId == projeId).Include(k => k.Kategori).Include(a => a.AltGorevs).Include(g => g.GorevNots).ThenInclude(gk => gk.NotSahibi).Include(p => p.GorevSahibi).OrderBy(t=>t.Tamamlandi).ThenBy(b=>b.BitisTarihi).ToList();
            GorevBilgileri = data.Select(x => new GorevYardimcisi(x)).ToList();
            return data;
        }
        public void GoreviBitir(Gorev gorev)
        {
            gorev.BitisTarihi = DateTime.Today;
            gorev.Tamamlandi = true;
            db.Gorevs.Update(gorev);
            db.SaveChanges();
        }
        public List<GorevKategori> KategorileriGetir()
        {
            return db.GorevKategoris.ToList();
        }
        public List<Kullanici> KullanicilariGetir()
        {
            return db.Kullanicis.Include(x=>x.Gorevs).Select(x=>new Kullanici() { Id=x.Id, AdiSoyadi=x.AdiSoyadi, KullaniciAdi=x.KullaniciAdi, Gorevs=x.Gorevs}).ToList();
        }
        public void GorevKayit(Gorev veri)
        {
            db.Gorevs.Add(veri); db.SaveChanges();
        }
        public void AltGorevKayit(AltGorev veri)
        {
            if (veri.Id==null|veri.Id==0)
            {
                db.AltGorevs.Add(veri);
            }
            else
            {
                db.AltGorevs.Update(veri);
            }
            db.SaveChanges();
        }
        public List<AltGorev> AltGorevleriGetir(int veriId)
        {
            return db.AltGorevs.Where(x=>x.GorevId==veriId).OrderBy(x=>x.Bittimi).ToList();
        }
        public List<GorevNot> GorevNotlariniGetir(int gorevId)
        {
            return db.GorevNots.Where(x=>x.GorevId==gorevId).OrderBy(x=>x.NotTarihi).ToList();
        }
        public void GorevNotKayit(GorevNot veri)
        {
            db.GorevNots.Add(veri);
            db.SaveChanges();
        }
        public List<ProjeNot> ProjeNotlariniGetir(int projeId)
        {
            return db.ProjeNots.Include(x=>x.Kullanic).ToList();
        }
        public void ProjeNotKayit(ProjeNot veri)
        {
            if (veri.Id == null | veri.Id == 0)
            {
                db.ProjeNots.Add(veri);
            }
            else
            {
                db.ProjeNots.Update(veri);
            }
            db.SaveChanges();
        }
        public List<Teknoloji> TeknolojileriGetir()
        {
            return db.Teknolojis.ToList();
        }
        public List<ProjeTeknoloji> ProjeninTeknolojileriniGetir(int projeId)
        {
            return db.ProjeTeknolojis.Where(x=>x.ProjeId == projeId).ToList();
        }
        public void TeknolojiEkle(Teknoloji veri)
        {
            if (veri.Id==null|veri.Id==0)
            {
                db.Teknolojis.Add(veri);
            }
            else
            {
                db.Teknolojis.Update(veri);
            }
            db.SaveChanges();
        }
        public void ProjeyeTeknolojiEkle(int teknolojiId, int projeId)
        {
            ProjeTeknoloji yeni=db.ProjeTeknolojis.FirstOrDefault(x=>x.ProjeId==projeId&&x.TeknolojiId==teknolojiId);
            if (yeni==null)
            {
                yeni = new ProjeTeknoloji()
                {
                    ProjeId = projeId,
                    TeknolojiId = teknolojiId
                };
                db.ProjeTeknolojis.Add(yeni);
                db.SaveChanges();
            }
        }
        public void TeknolojiCikar(int projeteknolojiId)
        {
            ProjeTeknoloji silinecek=db.ProjeTeknolojis.FirstOrDefault(x=>x.Id==projeteknolojiId);
            if (silinecek!=null)
            {
                db.ProjeTeknolojis.Remove(silinecek); db.SaveChanges();
            }
        }
        public void KullaniciEkle(Kullanici veri)
        {
            if (veri.Id!=null|veri.Id!=0)
            {
                db.Kullanicis.Add(veri);
            }
            else
            {
                db.Kullanicis.Update(veri);
            }
            db.SaveChanges();
        }

        public List<ProjeMaliyet> ButceKalemleriniGetir(int projeId)
        {
            return db.ProjeMaliyets.Where(x=>x.ProjeId==projeId).ToList();
        }
        public List<ProjeMaliyet> ButceKalemiEkleGuncelle(ProjeMaliyet veri)
        {
            if (veri.Id==null|veri.Id==0)
            {
                db.ProjeMaliyets.Add(veri);
            }
            else
            {
                db.ProjeMaliyets.Update(veri);
            }
            db.SaveChanges ();
            return ButceKalemleriniGetir(veri.ProjeId);
        }
        public Proje YeniProjeOlustur(Proje veri)
        {
            db.Projes.Add(veri);
            db.SaveChanges();
            return veri;
        }
    }
}
