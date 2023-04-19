using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Discount
    {
        [Key]
        public int? discount_id { get; set; }
        public string discount_name { get; set; }
        public int discount_percent { get; set; }

        //Navigation property
        public virtual ICollection<Product>? Products { get; set; }

    }
}