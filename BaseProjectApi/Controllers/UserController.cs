using BaseProjectApi.Data;
using BaseProjectApi.Models;
using BaseProjectApi.Repository;
using BaseProjectApi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> UsersList = await _userRepository.GetAll();
            return Ok(UsersList);
        }
        [HttpGet("/{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                User user = await _userRepository.Get(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> Add([FromBody] User user)
        {
            try
            {
                await _userRepository.Add(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
        }
        [HttpPut("/{id}")]
        public async Task<ActionResult> Update([FromBody]User user, int id)
        {
            try
            {
                user.Id = id;
                User usu = await _userRepository.Update(user, id);
                return Ok(usu);
            }
            catch (Exception ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
        }
        [HttpDelete("/{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            try
            {
                bool deleted = await _userRepository.Delete(id);
                return Ok("Usuário deletado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(401, new { message = ex.Message });
            }
            
        }
    }
}
