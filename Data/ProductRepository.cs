using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _dbContext;
        public ProductRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product Create(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Edit(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.products.ToList();
        }

        public Product GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductByStockId(int stockId)
        {
            throw new NotImplementedException();

        }

        public List<Product> GetProductsByStockId(int stockId)
        {
            throw new NotImplementedException();
        }
    }
}
