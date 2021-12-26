using Microsoft.AspNetCore.Mvc;
using Snap_n_go.Data;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Snap_n_go.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ProductController>
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productRepository.GetAllProducts());
            }
            catch
            {
                return NotFound();
            }
        }

        //GET api/<ProductController>/5   
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_productRepository.GetProductById(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("barcode/{barcode}")]
        public IActionResult GetProductByBarcode(long barcode)
        {
            try
            {
                return Ok(_productRepository.GetProductByBarcode(barcode));
            }
            catch
            {
                return NotFound();
            }
        }
        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (product != null)
            {
                _productRepository.Create(product);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }

            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (product != null)
            {
                _productRepository.Edit(product);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }

            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var prod = _productRepository.GetProductById(id);
            if(prod != null)
            {
                _productRepository.Delete(prod);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success"
                });
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
