using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjeTakipUygulamasi.Models.MyDataBase
{
    [Table("GorevNot")]
    public partial class GorevNot
    {
        [Key]
        public int Id { get; set; }
        public int GorevId { get; set; }
        public string NotIcerigi { get; set; } = null!;
        [Column(TypeName = "datetime")]
        public DateTime NotTarihi { get; set; }
        public int NotSahibiId { get; set; }

        [ForeignKey("GorevId")]
        [InverseProperty("GorevNots")]
        public virtual Gorev Gorev { get; set; } = null!;
        [ForeignKey("NotSahibiId")]
        [InverseProperty("GorevNots")]
        public virtual Kullanici NotSahibi { get; set; } = null!;
    }
}
