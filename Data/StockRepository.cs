using Microsoft.EntityFrameworkCore;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public class StockRepository:IStockRepository
    {
        private readonly MyDbContext _dbContext;
        public StockRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Stock> GetAllStocks() //done
        {
            var stocks = _dbContext.stocks
                .Include(s => s.User)
                .ToList();
            Console.WriteLine("stocks -->" + stocks);
            return stocks;
        }

        public Stock GetStockById(int id) //done 
        {
            if (id == null) return null;
            return _dbContext.stocks
                .Where(s => s.Id == id)
                //.Include(s=>s.User)
                .Include(s => s.StockProducts)
                .FirstOrDefault();
        }
        public List<Stock> GetStockByUserId(int userId) //done
        {
            if (userId == null) return null;
            return _dbContext.stocks
                .Where(s => s.UserId == userId)
                //.Include(s => s.Stocks)
                .ToList();
        }

        public Stock GetStockByName(string name) //done
        {
            if (name == "") return null;
            return _dbContext.stocks
                .Where(s => s.Name == name)
                .Include(s => s.StockProducts)
                //.Include(s => s.User)
                .FirstOrDefault();
        }
        public Stock Create(Stock stock,int userId) //done
        {
            stock.UserId = userId;
            _dbContext.stocks.Add(stock);
            stock.Id = _dbContext.SaveChanges();
            return stock;
        }
        public Stock Edit(Stock stock) //done
        {

            _dbContext.stocks.Update(stock);
            _dbContext.SaveChangesAsync();
            return stock;
        }

        public void Delete(Stock stock) //done
        {
            Console.WriteLine("stock in repo " + stock);
            _dbContext.stocks.Remove(stock);
            _dbContext.SaveChanges();
            Console.WriteLine("Stock having name "+ stock.Name+" successfully deleted..");
        }

    }
}
