using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Models
{
    public class Tbl_SlideImage
    {
        [Key]
        public int SlideId { get; set; }
        public string SlideTitle { get; set; }
        public string SlideImage { get; set; }
    }
}