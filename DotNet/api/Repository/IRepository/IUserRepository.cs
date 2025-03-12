using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Repository.IRepository
{
    public interface IUserRepository:IRepository.IRepository<User>
    {
        public void Update(User user);
    }
}