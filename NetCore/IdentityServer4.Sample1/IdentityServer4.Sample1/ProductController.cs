using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer4.Sample1
{
    [Authorize]
    public class ProductController : Controller
    {
        public ProductDto Get()
        {
            return new ProductDto
            {
                Id = 1,
                Name = "Test"
            };
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}