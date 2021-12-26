using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<StockProduct> StockProducts { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Isdeleted { get; set; }
        public string Address { get; set; }
        public string imgUrl { get; set; }

    }
}
