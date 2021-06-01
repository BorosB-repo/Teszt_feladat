using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Teszt_feladat.DTO;
using Teszt_feladat.Entities;

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
        public async Task<IEnumerable<MeasurementModel>> GetAllMeasurements()
        {
            return await Task<IEnumerable<MeasurementModel>>.Factory.StartNew(() =>
            {
                return this.context.Measurements.Select(measurement => new MeasurementModel()
                {
                    Id = measurement.Id,
                    Date = measurement.Date,
                    Flush = measurement.Flush,
                    Gap = measurement.Gap,
                    Shop = new ShopModel() { Name = measurement.Shop.Name, ShopId = measurement.ShopId },
                    Vechicle = new VechicleModel() { Id = measurement.Vechicle.VechicleId, JSN = measurement.Vechicle.JSN, Model = measurement.Vechicle.VechicleModel },
                    MeasurementPoint = new MeasurementPointModel() { MeasurementPointId = measurement.MeasurementPoint.MeasurementPointId, Name = measurement.MeasurementPoint.Name }
                }).AsEnumerable();
            });
        }

        [HttpPost]
        public async Task<ApiResult> UploadCsvFiles([FromForm] List<IFormFile> uploadModel)
        {
            return await Task.Factory.StartNew(() =>
            {
                ApiResult apires = new ApiResult()
                {
                    IsSuccess = false,
                    Message = "Name sikerült"
                };
                if (uploadModel != null && uploadModel.Count > 0)
                {
                    var newlyAddedVechicles = new List<Vechicle>();
                    var newlyAddedShops = new List<Shop>();
                    var newlyAddedMeasurePoints = new List<MeasurementPoint>();

                    foreach (var file in uploadModel)
                    {
                        #region store_lines_from_file
                        var list = new List<string[]>();
                        using (var reader = new StreamReader(file.OpenReadStream(), System.Text.Encoding.Latin1))
                        {
                            while (reader.Peek() >= 0)
                                list.Add(reader.ReadLine().Split(';'));
                        }
                        string[] headers = list[7].Select(x => x.Trim('"')).ToArray();
                        list.RemoveRange(0, 8);
                        #endregion

                        foreach (string[] line in list)
                        {
                            var trimmedLine = line.Select(x => x.Trim('"')).ToArray();

                            #region create_new_vechile_if_not_part_of_context_or_not_added_yet
                            apires.Message = "Valamely jármű hozzáadásánál hiba lépett fel.";
                            int indexOfJSN = Array.IndexOf(headers, "JSN");
                            int indexOfVechileModel = Array.IndexOf(headers, "Alkatrész");
                            var currentVechile = this.context.Vechicles
                                .FirstOrDefault(vechilce => vechilce.JSN == trimmedLine[indexOfJSN]
                                                && vechilce.VechicleModel == trimmedLine[indexOfVechileModel]);
                            if (currentVechile == null)
                                currentVechile = newlyAddedVechicles.FirstOrDefault(vechilce => vechilce.JSN == trimmedLine[indexOfJSN] &&
                                    vechilce.VechicleModel == trimmedLine[indexOfVechileModel]);

                            if (currentVechile == null)
                            {
                                currentVechile = new Vechicle()
                                {
                                    JSN = trimmedLine[indexOfJSN],
                                    VechicleModel = trimmedLine[indexOfVechileModel]
                                };
                            }

                            if (this.context.Entry(currentVechile).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                            {
                                this.context.Vechicles.Add(currentVechile);
                                this.context.SaveChanges();
                            }
                            #endregion

                            #region create_new_shop_if_not_part_of_context_or_not_added_yet
                            apires.Message = "Valamely Állomás hozzáadásánál hiba lépett fel.";
                            int indexOfShopName = Array.IndexOf(headers, "Állomás");
                            var currentShop = this.context.Shops.FirstOrDefault(shop => shop.Name == trimmedLine[indexOfShopName]);
                            if (currentShop == null)
                                currentShop = newlyAddedShops.FirstOrDefault(shop => shop.Name == trimmedLine[indexOfShopName]);
                            if (currentShop == null)
                                currentShop = new Shop()
                                {
                                    Name = trimmedLine[indexOfShopName]
                                };

                            if (this.context.Entry(currentShop).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                            {
                                this.context.Add(currentShop);
                                this.context.SaveChanges();
                            }
                            #endregion

                            #region create_new_measurepoint_if_not_part_of_context_or_not_added_yet
                            apires.Message = "Valamely mérési pont felvitelénél hiba lépett fel";
                            int indexOfMeasurePoint = Array.IndexOf(headers, "Mérési pont");
                            var currentMeasurementPoint = this.context.MeasurementPoints.FirstOrDefault(mp => mp.Name == trimmedLine[indexOfMeasurePoint]);
                            if (currentMeasurementPoint == null)
                                currentMeasurementPoint = newlyAddedMeasurePoints.FirstOrDefault(mp => mp.Name == trimmedLine[indexOfMeasurePoint]);

                            if (currentMeasurementPoint == null)
                                currentMeasurementPoint = new MeasurementPoint()
                                {
                                    Name = trimmedLine[indexOfMeasurePoint]
                                };

                            if (this.context.Entry(currentMeasurementPoint).State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                            {
                                this.context.MeasurementPoints.Add(currentMeasurementPoint);
                                this.context.SaveChanges();
                            }
                            #endregion

                            #region add_new_mesurement
                            apires.Message = "Valamely Mérés hozzáadásánál hiba lépett fel";
                            var newDate = trimmedLine[Array.IndexOf(headers, "Dátum")].Split('.');
                            var newTime = trimmedLine[Array.IndexOf(headers, "Idõpont")].Split(':');
                            var measurementDate = new DateTime();
                            if (newDate.Length >= 3 && newTime.Length == 3)
                            {
                                measurementDate = new DateTime().AddYears(Convert.ToInt32(newDate[0].Trim()))
                                                                .AddMonths(Convert.ToInt32(newDate[1].Trim()))
                                                                .AddDays(Convert.ToInt32(newDate[2].Trim()))
                                                                .AddHours(Convert.ToInt32(newTime[0].Trim()))
                                                                .AddMinutes(Convert.ToInt32(newTime[1].Trim()))
                                                                .AddSeconds(Convert.ToInt32(newTime[2].Trim()));
                            }


                            var currentMeasuremnt = this.context.Measurements
                                .FirstOrDefault(measurement =>
                                                measurement.VechicleId == currentVechile.VechicleId &&
                                                measurement.ShopId == currentShop.ShopId &&
                                                measurement.MeasurementPointId == currentMeasurementPoint.MeasurementPointId &&
                                                measurement.Date == measurementDate);

                            if (currentMeasuremnt == null)
                            {
                                int indexOfGap = Array.IndexOf(headers, "Gap");
                                int indexOfFlush = Array.IndexOf(headers, "Flush");
                                var newMeasurement = new Measurement();
                                newMeasurement.VechicleId = currentVechile.VechicleId;
                                newMeasurement.ShopId = currentShop.ShopId;
                                newMeasurement.MeasurementPointId = currentMeasurementPoint.MeasurementPointId;
                                newMeasurement.Gap = trimmedLine[indexOfGap] == "" ? null : Convert.ToDecimal(trimmedLine[indexOfGap]);
                                newMeasurement.Flush = trimmedLine[indexOfFlush] == "" ? null : Convert.ToDecimal(trimmedLine[indexOfFlush]);
                                newMeasurement.Date = measurementDate;
                                this.context.Measurements.Add(newMeasurement);
                                this.context.SaveChanges();
                            }
                            #endregion
                        }
                        apires.IsSuccess = true;
                        apires.Message = "Sikeres feldolgoztunk minden beküldött adatot.";
                    }
                }
                return apires;
            });
        }

    }

}
