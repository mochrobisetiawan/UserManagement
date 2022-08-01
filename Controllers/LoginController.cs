using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserManagementContext _context;

        public LoginController(UserManagementContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<bool> Login(string username, string password)
        {
          return await _context.Musers.AnyAsync(a => a.Username == username && a.Password == password);
        }
    }
}
