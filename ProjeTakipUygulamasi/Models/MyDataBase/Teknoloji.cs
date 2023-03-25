using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("Teknoloji")]
    public partial class Teknoloji
    {
        public Teknoloji()
        {
            ProjeTeknolojis = new HashSet<ProjeTeknoloji>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string TeknolojiAdi { get; set; } = null!;
        public string TeknolojiAciklama { get; set; } = null!;

        [InverseProperty("Teknoloji")]
        public virtual ICollection<ProjeTeknoloji> ProjeTeknolojis { get; set; }
    }
}
