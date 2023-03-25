using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("ProjeMaliyet")]
    public partial class ProjeMaliyet
    {
        [Key]
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public string Aciklama { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Tutar { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Tarih { get; set; }
        public bool GelirGider { get; set; }
        public bool Gerçeklesti { get; set; }
        public bool Vazgecildi { get; set; }

        [ForeignKey("ProjeId")]
        [InverseProperty("ProjeMaliyets")]
        public virtual Proje Proje { get; set; } = null!;
    }
}
