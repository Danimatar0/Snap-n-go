using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class StockProduct
    {
        [Key]
        public int Id { get; set; }
        [Column(Order = 0 )]
        public int StockId { get; set; }
        [Column(Order = 1)]
        public int ProductId { get; set; }

        public Stock Stock{ get; set; }

        public Product Product { get; set; }
        public double Quantity { get; set; }
        public string ExpiryDate { get; set; }

        public int Isdeleted { get; set; }

    }
}
