using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("Gorev")]
    public partial class Gorev
    {
        public Gorev()
        {
            AltGorevs = new HashSet<AltGorev>();
            GorevNots = new HashSet<GorevNot>();
        }

        [Key]
        public int Id { get; set; }
        public int ProjeId { get; set; }
        [StringLength(50)]
        public string GorevAdi { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime BaslangicTarihi { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BeklenenBitis { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BitisTarihi { get; set; }
        public bool Tamamlandi { get; set; }
        public int GorevSahibiId { get; set; }
        public int? KategoriId { get; set; }
        public string? SonNot { get; set; }

        [ForeignKey("GorevSahibiId")]
        [InverseProperty("Gorevs")]
        public virtual Kullanici GorevSahibi { get; set; } = null!;
        [ForeignKey("KategoriId")]
        [InverseProperty("Gorevs")]
        public virtual GorevKategori? Kategori { get; set; }
        [ForeignKey("ProjeId")]
        [InverseProperty("Gorevs")]
        public virtual Proje Proje { get; set; } = null!;
        [InverseProperty("Gorev")]
        public virtual ICollection<AltGorev> AltGorevs { get; set; }
        [InverseProperty("Gorev")]
        public virtual ICollection<GorevNot> GorevNots { get; set; }
    }
}
