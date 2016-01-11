﻿using APM.WebAPI.Models;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData;

namespace APM.WebAPI.Controllers
{
    [EnableCorsAttribute("http://localhost:52775", "*", "*")]
    public class ProductsController : ApiController
    {
        // GET: api/Products
        [EnableQuery()]
        public IQueryable<Product> Get()
        {
            var productRepository = new ProductRepository();
            return productRepository.Retrieve().AsQueryable();
        }

        //[EnableQuery()]
        //public IQueryable<Product> Get(string search)
        //{
        //    var productRepository = new ProductRepository();
        //    var products = productRepository.Retrieve();
        //    return products.Where(p => p.ProductCode.Contains(search)).AsQueryable();
        //}

        // GET: api/Products/5
        [Authorize()]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
