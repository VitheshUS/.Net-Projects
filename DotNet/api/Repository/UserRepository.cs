using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;

namespace api.Repository
{
    public class UserRepository :Repository.Repository<User>,IRepository.IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db):base(db)
        {
            _db=db;
        }
        public void Update(User user)
        {
            _db.User.Update(user);
        }
    }
}