using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt_feladat.Entities
{
    public class MeasurementPoint
    {
        [Key]
        public int MeasurementPointId { get; set; }

        [Column(TypeName ="nvarchar(50)")]
        public string Name { get; set; }

        public virtual ICollection<Measurement> Measurements { get; set; }
    }
}
