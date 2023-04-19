using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Shopping_session
    {
        [Key]
        public int? shopping_session_id { get; set; }
        public int total { get; set; }

        // Foreign key one to one 
        public int? user_id { get; set; }

        // Navigation properties
        public virtual ICollection<Cart_item>? Cart_items { get; set; }
        public virtual User? User { get; set; }

    }
}