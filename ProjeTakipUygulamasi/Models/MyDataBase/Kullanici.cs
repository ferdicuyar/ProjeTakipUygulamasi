using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("Kullanici")]
    public partial class Kullanici
    {
        public Kullanici()
        {
            GorevNots = new HashSet<GorevNot>();
            Gorevs = new HashSet<Gorev>();
            ProjeNots = new HashSet<ProjeNot>();
            Projes = new HashSet<Proje>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string KullaniciAdi { get; set; } = null!;
        [StringLength(50)]
        public string Sifre { get; set; } = null!;
        public string AdiSoyadi { get; set; } = null!;

        [InverseProperty("NotSahibi")]
        public virtual ICollection<GorevNot> GorevNots { get; set; }
        [InverseProperty("GorevSahibi")]
        public virtual ICollection<Gorev> Gorevs { get; set; }
        [InverseProperty("Kullanic")]
        public virtual ICollection<ProjeNot> ProjeNots { get; set; }
        [InverseProperty("ProjeSahibi")]
        public virtual ICollection<Proje> Projes { get; set; }
    }
}
