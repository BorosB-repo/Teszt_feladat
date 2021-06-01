using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teszt_feladat.DTO
{
    public class MeasurementModel
    {
        
        public int Id { get; set; }

        public VechicleModel Vechicle { get; set; }

        public ShopModel Shop { get; set; }

        public MeasurementPointModel MeasurementPoint { get; set; }

        public DateTime Date { get; set; }

        public decimal? Gap { get; set; }

        public decimal? Flush { get; set; }
    }
}
