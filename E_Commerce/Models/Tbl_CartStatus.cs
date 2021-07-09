using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Tbl_CartStatus
    {
        [Key]
        public int CartStatusId { get; set; }
        public string CartStatus { get; set; }
    }
}