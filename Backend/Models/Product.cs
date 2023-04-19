using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Product
    {
        [Key]
        public int? product_id { get; set; }
        public string product_name { get; set; }
        public string product_desc { get; set; }
        public double product_price { get; set; }
        public string product_image { get; set; }

        //Foreign keys one to one 
        //public int? cart_item_id { get; set; }
        //public int? order_item_id { get; set; }

        // Foreign key one to many
        public int? product_category_id { get; set; }
        public int? discount_id { get; set; }

        //Navigation property
        public virtual Product_category? Product_category { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual Order_item? Order_item { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual ICollection<Cart_item>? Cart_items { get; set; }
    }
}