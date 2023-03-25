using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("GorevKategori")]
    public partial class GorevKategori
    {
        public GorevKategori()
        {
            Gorevs = new HashSet<Gorev>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string KategoriAdi { get; set; } = null!;
        public string? Aciklama { get; set; }

        [InverseProperty("Kategori")]
        public virtual ICollection<Gorev> Gorevs { get; set; }
    }
}
