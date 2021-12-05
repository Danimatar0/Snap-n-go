using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public interface IStockProductRepository
    {
        List<StockProduct> GetAllStockProducts();
        StockProduct GetStockProductById(int id);
        List<StockProduct> GetStockProductByStockId(int stockid);
        List<StockProduct> GetStockProductByProductId(int productId);

        List<StockProduct> GetStockProductByStockName(string name);
        List<StockProduct> GetStockProductByProductName(string name);
        List<Product> GetProductsByStockId(int stockId);
        List<Stock> GetStocksByProductId(int pId);

        StockProduct Create(StockProduct product);
        StockProduct Edit(StockProduct product);
        void Delete(StockProduct product);
    }
}
