using Microsoft.AspNetCore.Mvc;
using Shop.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class ProductsController : Controller
    {
        private readonly IProductRepository productsRepository;

        public ProductsController(IProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }


        [HttpGet]
        public IActionResult GetProducts() {

            return Ok(this.productsRepository.GetAll());
        }
      
    }
}
