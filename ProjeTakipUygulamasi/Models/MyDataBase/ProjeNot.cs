using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("ProjeNot")]
    public partial class ProjeNot
    {
        [Key]
        public int Id { get; set; }
        public string Icerik { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime Tarih { get; set; }
        public int KullanicId { get; set; }
        public int ProjeId { get; set; }
        public bool Gundemde { get; set; }

        [ForeignKey("KullanicId")]
        [InverseProperty("ProjeNots")]
        public virtual Kullanici Kullanic { get; set; } = null!;
        [ForeignKey("ProjeId")]
        [InverseProperty("ProjeNots")]
        public virtual Proje Proje { get; set; } = null!;
    }
}
