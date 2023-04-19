using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Payment_detail
    {
        [Key]
        public int? payment_detail_id { get; set; }
        public double pay_amount { get; set; }
        public bool status { get; set; }

        // Foreign key one to one 
        public int? order_detail_id { get; set; }

        // Navigation properties
        public virtual Order_detail? Order_detail { get; set; }

    }
}