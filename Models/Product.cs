using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public  Category Category { get; set; }
        public int CategoryId { get; set; }
        public  List<StockProduct> StockProducts { get; set; }
        public int Isdeleted { get; set; }
        public string ImgUrl { get; set; }
        public long Barcode { get; set; }

    }
}
