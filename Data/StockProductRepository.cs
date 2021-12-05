using Microsoft.EntityFrameworkCore;
using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public class StockProductRepository : IStockProductRepository
    {
        private readonly MyDbContext _dbContext;
        public StockProductRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public StockProduct Create(StockProduct sp)
        {
            _dbContext.StockProducts.Add(sp);
            sp.Id=_dbContext.SaveChanges();
            return sp;
        }

        public void Delete(StockProduct product)
        {
            _dbContext.StockProducts.Remove(product);
            _dbContext.SaveChanges();
        }

        public StockProduct Edit(StockProduct product)
        {
            _dbContext.StockProducts.Update(product);
            _dbContext.SaveChanges();
            return product;
        }

        public List<StockProduct> GetAllStockProducts() //done
        {
            return _dbContext.StockProducts.ToList();
        }

        public StockProduct GetStockProductById(int id) //done
        {
            return _dbContext.StockProducts
                .Where(sp => sp.Id == id)
                .FirstOrDefault();
        }

        public List<StockProduct> GetStockProductByStockName(string name)
        {
            return _dbContext.StockProducts
                    .Where(sp => sp.Stock.Name.Equals(name))
                    .ToList();
        }

        public List<StockProduct> GetStockProductByProductId(int productId)
        {
            return _dbContext.StockProducts
                .Where(sp => sp.ProductId == productId)
                .Include(sp => sp.Product)
                .ToList();
        }

        //public List<Product> GetProductByStockId(int stockId)
        //{
        //    var entries = _dbContext.StockProducts
        //        .Where(sp => sp.Stock.Id == stockId)
        //        .Select(ps => ps.Product)
        //        .ToList();
        //    return entries;
        //}

        public List<StockProduct> GetStockProductByStockId(int stockid)
        {
            return _dbContext.StockProducts
            .Where(sp => sp.StockId == stockid)
            .Include(sp=>sp.Stock)
            .ToList();
        }

        public List<StockProduct> GetStockProductByProductName(string name)
        {
            return _dbContext.StockProducts
                .Where(sp=>sp.Product.Name.Equals(name))
                .ToList();
        }

        public List<Product> GetProductsByStockId(int stockId)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetStocksByProductId(int pId)
        {
            throw new NotImplementedException();
        }
    }
}
