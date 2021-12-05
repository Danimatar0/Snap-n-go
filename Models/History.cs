using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public  Product ScannedObject { get; set; }
        public int ProductId { get; set; }
        public  List<User> User { get; set; }
    }
}
