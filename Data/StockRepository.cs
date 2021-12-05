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
            return _dbContext.stocks
                .Include(s => s.User)
                .ToList();
        }

        public Stock GetStockById(int id) //done by commenting list of stocks in user model
        {
            if (id == null) return null;
            return _dbContext.stocks
                .Where(s => s.Id == id)
                .Include(s=>s.User)
                .FirstOrDefault();
        }
        public List<Stock> GetStockByUserId(int userId) //done
        {
            if (userId == null) return null;
            return _dbContext.stocks
                .Where(s => s.UserId == userId).ToList();
        }

        public Stock GetStockByName(string name) //done
        {
            if (name == "") return null;
            return _dbContext.stocks
                .Where(s => s.Name == name)
                .Include(s => s.StockProducts)
                .FirstOrDefault();
        }
        public Stock Create(Stock stock) //done
        {
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
            _dbContext.stocks.Remove(stock);
            _dbContext.SaveChangesAsync();
            Console.WriteLine("Stock having name "+ stock.Name+" successfully deleted..");
        }

    }
}
