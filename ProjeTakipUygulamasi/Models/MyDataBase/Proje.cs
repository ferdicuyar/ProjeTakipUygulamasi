using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("Proje")]
    public partial class Proje
    {
        public Proje()
        {
            Gorevs = new HashSet<Gorev>();
            ProjeMaliyets = new HashSet<ProjeMaliyet>();
            ProjeNots = new HashSet<ProjeNot>();
            ProjeTeknolojis = new HashSet<ProjeTeknoloji>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ProjeAdi { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime OlusturmaTarihi { get; set; }
        public int ProjeSahibiId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ProjeBitis { get; set; }
        public bool ProjeBittimi { get; set; }

        [ForeignKey("ProjeSahibiId")]
        [InverseProperty("Projes")]
        public virtual Kullanici ProjeSahibi { get; set; } = null!;
        [InverseProperty("Proje")]
        public virtual ICollection<Gorev> Gorevs { get; set; }
        [InverseProperty("Proje")]
        public virtual ICollection<ProjeMaliyet> ProjeMaliyets { get; set; }
        [InverseProperty("Proje")]
        public virtual ICollection<ProjeNot> ProjeNots { get; set; }
        [InverseProperty("Proje")]
        public virtual ICollection<ProjeTeknoloji> ProjeTeknolojis { get; set; }
    }
}
