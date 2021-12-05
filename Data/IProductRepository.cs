using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> GetProductsByStockId(int stockId);
        Product GetProductByName(string name);
        Product Create(Product product);
        Product Edit(Product product);
        void Delete(Product product);
    }
}
