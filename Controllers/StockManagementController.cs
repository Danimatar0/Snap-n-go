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
    public class StockManagementController : ControllerBase
    {
        private readonly IStockProductRepository _stockProductRepository;

        public StockManagementController(IStockProductRepository stockRepository)
        {
            _stockProductRepository = stockRepository;
        }
        // GET: api/<StockManagementController>
        [HttpGet]
        public async Task<IActionResult> Get() //done
        {

            try
            {
                return Ok(_stockProductRepository.GetAllStockProducts());
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/<StockManagementController>/5
        [HttpGet("product/{id}")]
        public IActionResult GetByProductId(int id)
        {
            try
            {
                return Ok(_stockProductRepository.GetStockProductByProductId(id));
            }
            catch
            {
                return NotFound();
            }
        }
        // GET api/<StockManagementController>/5
        [HttpGet("stock/{id}")]
        public IActionResult GetByStockId(int id)
        {
            try
            {
                return Ok(_stockProductRepository.GetStockProductByStockId(id));
            }
            catch
            {
                return NotFound();
            }
        }
        // GET api/<StockManagementController>/5
        [HttpGet("product/barcode/{barcode}")]
        public IActionResult GetByProductBarcode(long barcode)
        {
            try
            {
                return Ok(_stockProductRepository.GetStockProductByBarcode(barcode));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/<StockManagementController>
        [HttpPost]
        public IActionResult Post([FromBody] StockProduct sp)
        {
            try
            {
                _stockProductRepository.Create(sp);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }
            catch
            {
                return BadRequest(); 
            }
        }

        // PUT api/<StockManagementController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StockProduct sp)
        {
            try
            {
                _stockProductRepository.Edit(sp);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<StockManagementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
