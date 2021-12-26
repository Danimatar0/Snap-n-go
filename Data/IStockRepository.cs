using Snap_n_go.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Data
{
    public interface IStockRepository
    {
        List<Stock> GetAllStocks();
        Stock GetStockById(int id);
        List<Stock> GetStockByUserId(int userId);
        Stock GetStockByName(string name);
        Stock Create(Stock stock,int uId);
        Stock Edit(Stock stock);
        void Delete(Stock stock);
    }
}
