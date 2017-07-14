using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ReactSeedProject.Sample1.Models;

namespace ReactSeedProject.Sample1.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        [HttpGet(Name = "list")]
        public List<ProductModel> List()
        {
            var result = new List<ProductModel>
            {
                new ProductModel
                {
                    Id = 1,
                    Office =  "Edinburgh",
                    Age =61,
                    StartDate = new DateTime(2014,1,5)
                },
                new ProductModel
                {
                    Id = 2,
                    Office =  "Tokyo",
                    Age =21,
                    StartDate = new DateTime(2014,1,5)
                },
                new ProductModel
                {
                    Id = 3,
                    Office =  "New York",
                    Age =25,
                    StartDate = new DateTime(2016,1,5)
                },

            };


            return result;
        }
    }
}