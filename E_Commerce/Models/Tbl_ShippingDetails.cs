using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Tbl_ShippingDetails
    {
        [Key]
        public int ShippingDetailId { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public int OrderId { get; set; }
        public decimal AmountPaid{ get; set; }
        public string PaymentType { get; set; }
        public string userID { get; set; }
        [ForeignKey("userID")]
        public virtual ApplicationUser cartUser { get; set; }


    }
}