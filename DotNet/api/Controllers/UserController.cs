using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController :ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db) //Dependency Injection
        {
            _db=db;
        }

        [HttpGet]
        public IActionResult GetAll(){
            var users=_db.User.ToList().Select(u=>u.ToUserDto());
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute]int id){
            var user=_db.User.Find(id);

            if(user==null)
                return NotFound();
            else 
                return Ok(user.ToUserDto());
        }
    }
}