using FixedRateCashflowCalculator.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FixedRateCashflowCalculator.API.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
            {
            new Product { Id = 1, Amount = 4522, Duration = 12, Rate = 2.3M },
            new Product { Id = 2, Amount = 7511, Duration = 12, Rate = 1.4M},
            new Product { Id = 3, Amount = 8511, Duration = 7, Rate = 7.8M }
            };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
