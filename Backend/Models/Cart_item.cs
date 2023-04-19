using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Cart_item
    {
        [Key]
        public int? cart_item_id { get; set; }
        public int? quantity { get; set; }

        // Foreign key one to many 
        public int? shopping_session_id { get; set; }
        public int? product_id { get; set; }




        //Navigation property
        public virtual Shopping_session? Shopping_session { get; set; }
        public virtual Product? Product { get; set; }
    }
}