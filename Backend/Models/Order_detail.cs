using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Order_detail
    {
        [Key]
        public int? order_detail_id { get; set; }
        public int order_amount { get; set; }

        // Foreign key one to one 
        public int? user_id { get; set; }

        //Navigation property
        public virtual ICollection<Order_item>? Order_items { get; set; }
        public virtual Payment_detail? Payment_detail { get; set; }
        public virtual User? User { get; set; }
    }
}