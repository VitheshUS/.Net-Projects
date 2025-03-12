using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mapper
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User Model){
            return new UserDto{
                Id=Model.Id,
                Name=Model.Name,
                PhoneNumber=Model.PhoneNumber,
                Email=Model.Email,
                RegisteredOn=Model.RegisteredOn
            };
        }
    }
}