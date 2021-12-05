using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public  List<Product> Products { get; set; }
        public int Isdeleted { get; set; }

        public Category()
        {

        }
    }
}
