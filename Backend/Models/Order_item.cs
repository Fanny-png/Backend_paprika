using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Order_item
    {
        [Key]
        public int? order_item_id { get; set; }
        public int quantity { get; set; }

        // Foreign key one to many
        public int order_detail_id { get; set; }

        //Foregin key one to one 
        public int product_id { get; set; }

        // Navigation properties
        public virtual Product? Product { get; set; }
        public virtual Order_detail? Order_detail { get; set; }
    }
}