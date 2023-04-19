using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Product_category
    {
        [Key]
        public int? product_category_id { get; set; }
        public string category_name { get; set; }

        // Navigation properties
        public virtual ICollection<Product>? Products { get; set; }
    }
}