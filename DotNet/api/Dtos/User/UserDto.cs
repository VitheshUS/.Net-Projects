using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public  class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string Email { get; set; }=string.Empty;
        public long PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
    }
}