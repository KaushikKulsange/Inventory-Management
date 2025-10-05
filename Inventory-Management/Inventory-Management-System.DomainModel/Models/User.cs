using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Management_System.DomainModel.Models
{
        public class User
        {
            [Key] // Primary key
            public int UserId { get; set; }

            [Required]
            [MaxLength(25)]
            public string Username { get; set; }

            [Required]
            [Length(4,15)]
            public string Password { get; set; }

            [Required]
            [MaxLength(20)]
            public string Role { get; set; }
        }
}
