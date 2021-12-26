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
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> GetProductByBarcode(int barcode)
        {
            try
            {
                return Ok(_productRepository.GetProductById(barcode));
            }
            catch
            {
                return NotFound();
            }
        }
        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
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
        public async Task<IActionResult> Put(int id, [FromBody] Product product)
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
        public void Delete(int id)
        {
        }
    }
}
