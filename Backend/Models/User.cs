using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class User
    {
        [Key]
        public int? user_id { get; set; }
        public string user_firstname { get; set; }
        public string user_lastname { get; set; }
        public string user_email { get; set; }
        public string user_address { get; set; }
        public string user_country { get; set; }
        public string user_city { get; set; }
        public string user_zipcode { get; set; }
        public string user_mobilephone { get; set; }

        // Foreign key one to one 
        //public int? order_detail_id { get; set; }

        // Navigation properties
        public virtual ICollection<Review>? Reviews { get; set; }
        public virtual Shopping_session? Shopping_session { get; set; }
        public virtual Order_detail? Order_detail { get; set; }
    }
}