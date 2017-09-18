using Microsoft.AspNetCore.Authorization;
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
                Name = "Test",
                UserName = this.User?.Identity?.Name
            };
        }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}