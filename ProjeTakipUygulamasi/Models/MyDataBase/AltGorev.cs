using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("AltGorev")]
    public partial class AltGorev
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string AltGorevAdi { get; set; } = null!;
        public string? Aciklama { get; set; }
        public bool Bittimi { get; set; }
        public int GorevId { get; set; }

        [ForeignKey("GorevId")]
        [InverseProperty("AltGorevs")]
        public virtual Gorev Gorev { get; set; } = null!;
    }
}
