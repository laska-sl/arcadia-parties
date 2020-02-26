using ArcadiaParties.Data.Abstractions.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadiaParties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {        
        private readonly IUserRepository _repo;
        public UsersController(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            return Ok(users);
        }

        [HttpGet("{identity}")]
        public async Task<IActionResult> GetUser(string identity)
        {
            var user = await _repo.GetUser(identity);

            return Ok(user);
        }

    }
}
