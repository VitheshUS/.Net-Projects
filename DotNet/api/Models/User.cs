using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }=string.Empty;

        [Required]
        public string Password { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }=string.Empty;

        [Phone]
        [Required]
        public long PhoneNumber { get; set; }

        public DateTime RegisteredOn{ get; set; } = DateTime.Now;
    }
}