using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teszt_feladat.DTO;

namespace Teszt_feladat
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly AvanderDbContext context;

        public MeasurementController(IConfiguration configuration, AvanderDbContext context)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        [HttpGet]
        public async Task<IEnumerable<MeasurementModel>> GetAllMeasurement()
        {
            return await Task<IEnumerable<MeasurementModel>>.Factory.StartNew(() =>
            {
                return this.context.Measurements.Select(x => new MeasurementModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    Flush = x.Flush,
                    Gap = x.Gap,
                    Shop = new ShopModel() { Name = x.Shop.Name, ShopId = x.ShopId },
                    Vechicle = new VechileModel() {Id = x.VechicleId, JSN = x.Vechicle.JSN, VechilceModel = x.Vechicle.VechicleModel }
                }).AsEnumerable();
            });
        }
    }
}
