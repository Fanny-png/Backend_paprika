using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Review
    {
        [Key]
        public int? review_id { get; set; }
        public string review_text { get; set; }
        public int review_rating { get; set; }
 


        // Foreign key one to many
        public int product_id { get; set; }
        public int user_id { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}