using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
   
    public class ApplicationDBContext :IdentityDbContext
    {
        
        public ApplicationDBContext() : base("CS")
        {


        }
        public ApplicationDBContext(string connectionName):base(connectionName)
        {

        }
      
        public DbSet<Tbl_Cart> carts { get; set; }
        public DbSet <Tbl_CartStatus> cartStatus { get; set; }
        public DbSet<Tbl_Product> products { get; set; }
        public DbSet<Tbl_Category> categories { get; set; }
        public DbSet<Tbl_ShippingDetails> shippingDetails { get; set; }
        public DbSet<Tbl_SlideImage> slideImages { get; set; }
    }
}