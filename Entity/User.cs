using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
