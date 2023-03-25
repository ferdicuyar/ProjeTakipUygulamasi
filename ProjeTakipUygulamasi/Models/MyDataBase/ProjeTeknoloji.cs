using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("ProjeTeknoloji")]
    public partial class ProjeTeknoloji
    {
        [Key]
        public int Id { get; set; }
        public int ProjeId { get; set; }
        public int TeknolojiId { get; set; }

        [ForeignKey("ProjeId")]
        [InverseProperty("ProjeTeknolojis")]
        public virtual Proje Proje { get; set; } = null!;
        [ForeignKey("TeknolojiId")]
        [InverseProperty("ProjeTeknolojis")]
        public virtual Teknoloji Teknoloji { get; set; } = null!;
    }
}
