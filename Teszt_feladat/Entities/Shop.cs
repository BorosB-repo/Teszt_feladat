using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt_feladat.Entities
{
    public class Shop
    {
        [Key]
        public int ShopId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
