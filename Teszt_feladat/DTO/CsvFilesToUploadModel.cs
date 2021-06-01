using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teszt_feladat.DTO
{
    public class CsvFilesToUploadModel
    {
        public List<IFormFile> files { get; set; }
    }
}
