using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ujjwal_Srivastava_Sprint_I.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ujjwal_Srivastava_Sprint_I.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        List<User> userList = new List<User> {
            new User{ID=1, FirstName="John", SecondName="Doe", Email="john.doe@test.com", Password="Password1"},
            new User{ID=2, FirstName="John", SecondName="Skeet", Email="john.skeet@test.com", Password="Password1"},
            new User{ID=3, FirstName="Mark", SecondName="Seeman", Email="mark.seeman@test.com", Password="Password1"},
            new User{ID=4, FirstName="Bob", SecondName="Martin", Email="bob.martin@test.com", Password="Password1"}
        };

        [HttpPost]
        [Route("user/create")]
        public ActionResult CreateUser(User user)
        {
            if(userList.FirstOrDefault(x => x.ID == user.ID)==null)
            {
                userList.Add(user);
            }
            else
            {
                return BadRequest("ID must be unique");
            }
            return Ok();
        }

        [HttpGet]
        [Route("user/get")]
        public ActionResult<List<User>> GetAllUsers()
        {
            return Ok(userList);
        }

        [HttpGet]
        [Route("user/get/{id}")]
        public ActionResult<User> GetUserFromId(int id)
        {
            var user = userList.FirstOrDefault(x => x.ID == id);
            if (user == null)
            {
                return BadRequest("user doesn't exist");
            }
            return Ok(user);
        }

        [HttpPut]
        [Route("user/update")]
        public ActionResult<User> UpdateUser(User user)
        {
            var updateUser = userList.FirstOrDefault(x => x.ID == user.ID);
            if (updateUser == null)
            {
                return BadRequest("user doesn't exist");
            }
            updateUser.FirstName = user.FirstName;
            updateUser.SecondName = user.SecondName;
            updateUser.Email = user.Email;
            updateUser.Password = user.Password;
            return Ok(updateUser);
        }

        [HttpGet]
        [Route("user/login/{email}/{pwd}")]
        public ActionResult ValidateUser(string email, string pwd)
        {
            var loggedInUser = userList.FirstOrDefault(x=>x.Email==email && x.Password==pwd);
            if (loggedInUser == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok("User verified");
        }
    }
}
