using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace Backend.Models
{
    public class Admin
    {
        [Key]
        public int? admin_id { get; set; }
        public string admin_username { get; set; }
        public string admin_password { get; set; }
    }
}