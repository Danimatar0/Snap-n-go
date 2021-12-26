using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        List<Product> GetProductsByStockId(int stockId);
        Product GetProductByName(string name);
        Product GetProductByBarcode(long barcode);

        Product Create(Product product);
        Product Edit(Product product);
        void Delete(Product product);
    }
}
