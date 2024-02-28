﻿using System;

namespace MNG.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime Register_Date { get; set; }
        public int Position { get; set; }
        public int Department {  get; set; }
        public bool Inactive { get; set; }
    }
}
