using System;

namespace MNG.APIs.Models
{
  public class User
  {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime Regist_Date { get; set; }
        public int Position { get; set; }
        public int Department { get; set; }
        public bool Inactive { get; set; }
    }
}
