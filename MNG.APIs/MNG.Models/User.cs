using MNG.Models.Productions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MNG.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime Register_Date { get; set; }
        public int Position { get; set; }
        public int Department {  get; set; }
        public bool Inactive { get; set; }
    }
}
