using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Snap_n_go.Data;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Snap_n_go.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        // GET: api/<StockController>
        private readonly IStockRepository _stockRepository;
        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetStocks()    //done
        {
            try
            {
                return Ok(_stockRepository.GetAllStocks());
            }
            catch
            {
                return NotFound();
            }
        }

        // GET api/<StockController>/5
        [HttpGet("stock/{id}")]
        public IActionResult GetById(int id)
        {
            var stock = _stockRepository.GetStockById(id);
            if (stock == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stock);
            }
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetByUserId(int userId)    //done
        {
            var stocks = _stockRepository.GetStockByUserId(userId);
            if (stocks == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stocks);
            }
        }

        // POST api/<StockController>
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Stock stock,int uId)   //done
        {
            if(stock != null)
            {
                _stockRepository.Create(stock, uId);
                return Ok(new {
                    statusCode = 200,
                    message = "Success",
                });
            }

            else
            {
                return BadRequest();
            }
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Stock stock) //done
        {
            if (id == null)
            {
                return NotFound();
            }
            var s = _stockRepository.GetStockById(id);
            if (s == null)
            {
                return NotFound();
            }
            var newStock = _stockRepository.Edit(stock);
            return Ok(new
            {
                statusCode = 200,
                message = "Success",
            });
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) //done
        {
            if (id == null) return BadRequest();
            else
            {
                var stock = _stockRepository.GetStockById(id);
                Console.WriteLine("stock in controller " + stock);
                 _stockRepository.Delete(stock);
                return Ok(new
                {
                    statusCode = 200,
                    message = "Success",
                });
            }
        }
    }
}
