using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teszt_feladat.Entities
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Vechicle")]
        public int VechicleId { get; set; }

        public virtual Vechicle Vechicle { get; set; }

        [ForeignKey("Shop")]
        public int ShopId { get; set; }

        public virtual Shop Shop { get; set; }

        [ForeignKey("MeasurementPoint")]
        public int MeasurementPointId { get; set; }

        public virtual MeasurementPoint MeasurementPoint { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Gap { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal? Flush { get; set; }
    }
}
