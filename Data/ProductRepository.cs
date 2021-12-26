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
           _dbContext.products.Add(product);
            product.Id=_dbContext.SaveChanges();
            return product;
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

        public Product GetProductByBarcode(int barcode)
        {
            return _dbContext.products
                .Where(s=>s.barcode == barcode)
                .FirstOrDefault();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.products.Find(id);
        }

        public Product GetProductByName(string name)
        {
            return _dbContext.products
                .Where(p=>p.Name.Equals(name))
                .FirstOrDefault();
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
