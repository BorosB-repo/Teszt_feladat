

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt_feladat.Entities
{
    public class Vechicle
    {
        [Key]
        public int VechicleId { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string JSN { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string VechicleModel { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
