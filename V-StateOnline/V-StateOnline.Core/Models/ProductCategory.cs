﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace V_StateOnline.Core.Models
{
   
    

    public class ProductCategory
    {
        public string Id { get; set; }
        [StringLength(30)]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0,50000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public ProductCategory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
