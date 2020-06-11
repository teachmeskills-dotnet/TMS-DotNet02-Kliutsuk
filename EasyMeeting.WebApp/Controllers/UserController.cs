using EasyMeeting.Common.Interfaces;
using EasyMeeting.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EasyMeeting.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<Users> _userRepository;
        public UserController(IRepository<Users> userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAll().ToListAsync();

            users.ForEach(user => Console.WriteLine(users));
            return Ok(users);
        }
    }
}
