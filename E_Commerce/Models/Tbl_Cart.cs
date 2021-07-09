using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Tbl_Cart
    {
        [Key]
        public int CartId { get; set; }
        public List<Tbl_Product> Product { get; set; }
        public Tbl_CartStatus CartStatus { get; set; }
        public string userID { get; set; }
        [ForeignKey("userID")]
        public virtual ApplicationUser cartUser { get; set; }

    }
}