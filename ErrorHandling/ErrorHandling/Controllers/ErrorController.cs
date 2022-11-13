using ErrorHandling.DBOperations;
using ErrorHandling.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorHandling.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class ErrorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ErrorController (AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] User newUser)
        {
            var user = _context.Users.SingleOrDefault( x => x.UserId == newUser.UserId );
            if (user is not null)
                return BadRequest("This id number is already exist.");
            _context.Users.Add(newUser);

            _context.SaveChanges();
            return Ok("New User Info is added.");
        } 

        [HttpGet("AllUsers")]
        public List<User> GetUsers()
        {
            var userList=_context.Users.OrderBy(x => x.UserId).ToList<User>();
            return userList;
        }


        [HttpGet("{id}")]
        public User GetById(int id)
        {
            var user = _context.Users.Where(user => user.UserId == id).SingleOrDefault();
            return user;
        }


        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == id);
            if (user is null)
                return BadRequest();

            user.UserId = updatedUser.UserId != default ? updatedUser.UserId : user.UserId;
            user.UserName = updatedUser.UserName != default ? updatedUser.UserName : user.UserName;
            user.UserSurname = updatedUser.UserSurname != default ? updatedUser.UserSurname : user.UserSurname;
            user.UserGender= updatedUser.UserGender != default ? updatedUser.UserGender : user.UserGender;
            user.RegisteredDate = updatedUser.RegisteredDate != default ? updatedUser.RegisteredDate : user.RegisteredDate;

            _context.SaveChanges();
            return Ok(updatedUser);
        }


        [HttpDelete("Delete")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(x => x.UserId == id);
            if (user is null)
                return BadRequest("Check id number!");
            _context.Users.Remove(user);

            _context.SaveChanges();
            return Ok($"UserId number : {id} is deleted.");
        }

    }
}
