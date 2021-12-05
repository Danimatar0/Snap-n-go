using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Snap_n_go.Models
{
    public class User
    {   
        [Key]
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public  List<History> Records { get; set; }
        public string Dob { get; set; }
        public int Isdeleted { get; set; }
        public List<Stock> Stocks { get; set; }
        public User()
        {

        }

    }
}
